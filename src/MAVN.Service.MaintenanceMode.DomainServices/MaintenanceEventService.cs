using System;
using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using MAVN.Service.MaintenanceMode.Domain;
using MAVN.Service.MaintenanceMode.Domain.Repositories;
using MAVN.Service.MaintenanceMode.Domain.Services;

namespace MAVN.Service.MaintenanceMode.DomainServices
{
    public class MaintenanceEventService : IMaintenanceEventService
    {
        private readonly IMaintenanceEventRepository _maintenanceEventRepository;
        private readonly ILog _log;

        private IMaintenanceDetails _currentMaintenance;
        private bool? _isInited;

        public MaintenanceEventService(IMaintenanceEventRepository maintenanceEventRepository, ILogFactory logFactory)
        {
            _maintenanceEventRepository = maintenanceEventRepository;
            _log = logFactory.CreateLog(this);
        }

        public async Task<IMaintenanceDetails> GetActiveMaintenanceDetailsAsync()
        {
            if (_isInited.HasValue && _isInited.Value)
                return _currentMaintenance;

            try
            {
                var currentMaintenanceStatus = await _maintenanceEventRepository.GetMaintenanceStatusAsync();
                _currentMaintenance = currentMaintenanceStatus;
                _isInited = true;
                return currentMaintenanceStatus;
            }
            catch (Exception e)
            {
                _log.Error(e);
                return null;
            }
        }

        public async Task<StartMaintenanceError> StartMaintenanceAsync(
            string who,
            string reason,
            TimeSpan plannedDuration)
        {
            var activeMaintenance = await GetActiveMaintenanceDetailsAsync();
            if (activeMaintenance != null)
                return StartMaintenanceError.AlreadyStarted;

            _currentMaintenance = await _maintenanceEventRepository.StartMaintenanceAsync(
                who,
                reason,
                plannedDuration);

            if (_isInited == null)
                _isInited = true;

            return StartMaintenanceError.None;
        }

        public Task StopMaintenanceAsync()
        {
            _currentMaintenance = null;
            return _maintenanceEventRepository.StopMaintenanceAsync();
        }
    }
}
