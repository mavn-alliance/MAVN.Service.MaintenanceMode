using System;
using System.Threading.Tasks;
using Lykke.Common.MsSql;
using MAVN.Service.MaintenanceMode.Domain;
using MAVN.Service.MaintenanceMode.Domain.Repositories;
using MAVN.Service.MaintenanceMode.MsSqlRepositories.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.MaintenanceMode.MsSqlRepositories
{
    public class MaintenanceEventRepository : IMaintenanceEventRepository
    {
        private readonly MsSqlContextFactory<MaintenanceEventContext> _contextFactory;

        public MaintenanceEventRepository(MsSqlContextFactory<MaintenanceEventContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IMaintenanceDetails> GetMaintenanceStatusAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var result = await context.ActiveMaintenances.SingleOrDefaultAsync();
                return result;
            }
        }

        public async Task<IMaintenanceDetails> StartMaintenanceAsync(
            string who,
            string reason,
            TimeSpan plannedDuration)
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var newMaintenance = ActiveMaintenanceEntity.Create(
                    who,
                    reason,
                    plannedDuration);
                context.ActiveMaintenances.Add(newMaintenance);

                await context.SaveChangesAsync();

                return newMaintenance;
            }
        }

        public async Task StopMaintenanceAsync()
        {
            using (var context = _contextFactory.CreateDataContext())
            {
                var activeMaintenance = await context.ActiveMaintenances.SingleOrDefaultAsync();
                if (activeMaintenance == null)
                    return;

                var historyEntity = MaintenanceEventEntity.Create(activeMaintenance);

                context.ActiveMaintenances.Remove(activeMaintenance);
                context.MaintenanceEvents.Add(historyEntity);

                await context.SaveChangesAsync();
            }
        }
    }
}
