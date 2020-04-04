using System;
using System.Threading.Tasks;

namespace MAVN.Service.MaintenanceMode.Domain.Repositories
{
    public interface IMaintenanceEventRepository
    {
        Task<IMaintenanceDetails> GetMaintenanceStatusAsync();

        Task<IMaintenanceDetails> StartMaintenanceAsync(
            string who,
            string reason,
            TimeSpan plannedDuration);

        Task StopMaintenanceAsync();
    }
}
