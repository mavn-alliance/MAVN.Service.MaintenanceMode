using System;

namespace Lykke.Service.MaintenanceMode.Domain
{
    public interface IMaintenanceDetails
    {
        TimeSpan PlannedDuration { get; }

        DateTime ActualStart { get; }

        string Who { get; }

        string Reason { get; }
    }
}
