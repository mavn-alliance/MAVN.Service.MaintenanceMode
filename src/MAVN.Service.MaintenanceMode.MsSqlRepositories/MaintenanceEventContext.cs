using JetBrains.Annotations;
using Lykke.Common.MsSql;
using MAVN.Service.MaintenanceMode.MsSqlRepositories.Entitites;
using Microsoft.EntityFrameworkCore;

namespace MAVN.Service.MaintenanceMode.MsSqlRepositories
{
    public class MaintenanceEventContext : MsSqlContext
    {
        private const string Schema = "maintenance";

        internal DbSet<ActiveMaintenanceEntity> ActiveMaintenances { get; set; }
        internal DbSet<MaintenanceEventEntity> MaintenanceEvents { get; set; }

        public MaintenanceEventContext()
            : base(Schema)
        {
        }

        [UsedImplicitly]
        public MaintenanceEventContext(DbContextOptions contextOptions)
            : base(Schema, contextOptions)
        {
        }

        public MaintenanceEventContext(string connectionString, bool isTraceEnabled = false)
            : base(Schema, connectionString, isTraceEnabled)
        {
        }

        [UsedImplicitly]
        public MaintenanceEventContext(string connectionString, bool isTraceEnabled, int commandTimeoutSeconds = 30)
            : base(Schema, connectionString, isTraceEnabled, commandTimeoutSeconds)
        {
        }

        protected override void OnLykkeConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnLykkeModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
