using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAVN.Service.MaintenanceMode.Domain;

namespace MAVN.Service.MaintenanceMode.MsSqlRepositories.Entitites
{
    [Table("maintenance_history")]
    public class MaintenanceEventEntity : IMaintenanceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public TimeSpan PlannedDuration { get; set; }

        [Required]
        public DateTime ActualStart { get; set; }

        [Required]
        public string Who { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public DateTime ActualFinish { get; set; }

        [Required]
        public TimeSpan ActualDuration { get; set; }

        public static MaintenanceEventEntity Create(ActiveMaintenanceEntity activeMaintenance)
        {
            var now = DateTime.UtcNow;
            return new MaintenanceEventEntity
            {
                PlannedDuration = activeMaintenance.PlannedDuration,
                ActualStart = activeMaintenance.ActualStart,
                Who = activeMaintenance.Who,
                Reason = activeMaintenance.Reason,
                ActualFinish = now,
                ActualDuration = now - activeMaintenance.ActualStart,
            };
        }
    }
}
