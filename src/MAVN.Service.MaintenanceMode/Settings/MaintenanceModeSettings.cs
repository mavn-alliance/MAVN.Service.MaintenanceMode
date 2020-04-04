using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace MAVN.Service.MaintenanceMode.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class MaintenanceModeSettings
    {
        public DbSettings Db { get; set; }
    }
}
