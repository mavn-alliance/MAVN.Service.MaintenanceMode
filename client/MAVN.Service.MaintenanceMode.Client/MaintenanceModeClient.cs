using Lykke.HttpClientGenerator;

namespace MAVN.Service.MaintenanceMode.Client
{
    /// <summary>
    /// MaintenanceMode API aggregating interface.
    /// </summary>
    public class MaintenanceModeClient : IMaintenanceModeClient
    {
        // Note: Add similar Api properties for each new service controller

        /// <summary>Inerface to MaintenanceMode Api.</summary>
        public IMaintenanceApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public MaintenanceModeClient(IHttpClientGenerator httpClientGenerator)
        {
            Api = httpClientGenerator.Generate<IMaintenanceApi>();
        }
    }
}
