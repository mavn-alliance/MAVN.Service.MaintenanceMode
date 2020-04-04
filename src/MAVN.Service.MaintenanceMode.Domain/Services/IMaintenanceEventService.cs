using System;
using System.Threading.Tasks;

namespace MAVN.Service.MaintenanceMode.Domain.Services
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
