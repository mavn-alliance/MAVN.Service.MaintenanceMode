using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MAVN.Service.MaintenanceMode.Domain;

namespace MAVN.Service.MaintenanceMode.MsSqlRepositories.Entitites
{
    [Table("maintenance")]
    public class ActiveMaintenanceEntity : IMaintenanceDetails
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

        public static ActiveMaintenanceEntity Create(
            string who,
            string reason,
            TimeSpan plannedDuration)
        {
            return new ActiveMaintenanceEntity
            {
                PlannedDuration = plannedDuration,
                ActualStart = DateTime.UtcNow,
                Who = who,
                Reason = reason,
            };
        }
    }
}
