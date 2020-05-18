using Autofac;
using JetBrains.Annotations;
using MAVN.Common.MsSql;
using MAVN.Service.MaintenanceMode.Domain.Repositories;
using MAVN.Service.MaintenanceMode.Domain.Services;
using MAVN.Service.MaintenanceMode.DomainServices;
using MAVN.Service.MaintenanceMode.MsSqlRepositories;
using MAVN.Service.MaintenanceMode.Settings;
using Lykke.SettingsReader;

namespace MAVN.Service.MaintenanceMode.Modules
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
            builder.RegisterMsSql(
                _connectionString,
                connectionString => new MaintenanceEventContext(connectionString),
                dbConnection => new MaintenanceEventContext(dbConnection)
                );

            builder.RegisterType<MaintenanceEventRepository>()
                .As<IMaintenanceEventRepository>()
                .SingleInstance();

            builder.RegisterType<MaintenanceEventService>()
                .As<IMaintenanceEventService>()
                .SingleInstance();
        }
    }
}
