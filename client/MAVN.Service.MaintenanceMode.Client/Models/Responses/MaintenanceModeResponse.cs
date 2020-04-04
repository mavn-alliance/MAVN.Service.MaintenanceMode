using System;

namespace MAVN.Service.MaintenanceMode.Client.Models.Responses
{
    /// <summary>
    /// Maintenance mode response
    /// </summary>
    public class MaintenanceModeResponse
    {
        /// <summary>Flag for maintenance mode activation status.</summary>
        public bool IsEnabled { get; set; }

        /// <summary>Actual maintenance start time.</summary>
        public DateTime? ActualStart { get; set; }

        /// <summary>Planned maintenance duration.</summary>
        public TimeSpan? PlannedDuration { get; set; }
    }
}
