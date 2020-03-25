using System;
using System.Threading.Tasks;

namespace Lykke.Service.MaintenanceMode.Domain.Services
{
    public interface IMaintenanceEventService
    {
        Task<IMaintenanceDetails> GetActiveMaintenanceDetailsAsync();

        Task<StartMaintenanceError> StartMaintenanceAsync(
            string who,
            string reason,
            TimeSpan plannedDuration);

        Task StopMaintenanceAsync();
    }
}
