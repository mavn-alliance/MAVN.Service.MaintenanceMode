using JetBrains.Annotations;

namespace MAVN.Service.MaintenanceMode.Client
{
    /// <summary>
    /// MaintenanceMode client interface.
    /// </summary>
    [PublicAPI]
    public interface IMaintenanceModeClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - IMaintenanceModeApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application Api interface</summary>
        IMaintenanceApi Api { get; }
    }
}
