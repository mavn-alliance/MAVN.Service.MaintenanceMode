using Autofac;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Lykke.Service.MaintenanceMode.Domain.Repositories;
using Lykke.Service.MaintenanceMode.Domain.Services;
using Lykke.Service.MaintenanceMode.DomainServices;
using Lykke.Service.MaintenanceMode.MsSqlRepositories;
using Lykke.Service.MaintenanceMode.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.MaintenanceMode.Modules
{
    [UsedImplicitly]
    public class ServiceModule : Module
    {
        private readonly string _connectionString;

        public ServiceModule(IReloadingManager<AppSettings> appSettings)
        {
            _connectionString = appSettings.CurrentValue.MaintenanceModeService.Db.DataConnString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterMsSql(() => new MaintenanceEventContext(_connectionString));

            builder.RegisterType<MaintenanceEventRepository>()
                .As<IMaintenanceEventRepository>()
                .SingleInstance();

            builder.RegisterType<MaintenanceEventService>()
                .As<IMaintenanceEventService>()
                .SingleInstance();
        }
    }
}
