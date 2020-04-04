using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace MAVN.Service.MaintenanceMode.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public MaintenanceModeSettings MaintenanceModeService { get; set; }
    }
}
