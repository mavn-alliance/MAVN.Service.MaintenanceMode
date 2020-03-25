using JetBrains.Annotations;
using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.MaintenanceMode.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class MaintenanceModeSettings
    {
        public DbSettings Db { get; set; }
    }
}
