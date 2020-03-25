using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.MaintenanceMode.Client.Models.Responses;
using Refit;

namespace Lykke.Service.MaintenanceMode.Client
{
    // This is an example of service controller interfaces.
    // Actual interface methods must be placed here (not in IMaintenanceModeClient interface).

    /// <summary>
    /// MaintenanceMode client API interface.
    /// </summary>
    [PublicAPI]
    public interface IMaintenanceApi
    {
        /// <summary>
        /// Gets info about current maintenance status.
        /// </summary>
        /// <returns><see cref="MaintenanceModeResponse"/></returns>
        [Get("/api/maintenance")]
        Task<MaintenanceModeResponse> GetActiveMaintenanceDetailsAsync();
    }
}
