using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;
using MAVN.Service.MaintenanceMode.Client;
using MAVN.Service.MaintenanceMode.Client.Models.Responses;
using MAVN.Service.MaintenanceMode.Domain.Services;
using MAVN.Service.MaintenanceMode.Models;
using Microsoft.AspNetCore.Mvc;

namespace MAVN.Service.MaintenanceMode.Controllers
{
    [Route("api/maintenance")]
    public class MaintenanceController : Controller, IMaintenanceApi
    {
        private readonly IMaintenanceEventService _maintenanceEventService;

        public MaintenanceController(IMaintenanceEventService maintenanceEventService)
        {
            _maintenanceEventService = maintenanceEventService;
        }

        /// <summary>
        /// Gets info about current maintenance status.
        /// </summary>
        /// <returns><see cref="MaintenanceModeResponse"/></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MaintenanceModeResponse), (int)HttpStatusCode.OK)]
        public async Task<MaintenanceModeResponse> GetActiveMaintenanceDetailsAsync()
        {
            var result = await _maintenanceEventService.GetActiveMaintenanceDetailsAsync();
            if (result == null)
                return new MaintenanceModeResponse { IsEnabled = false };
            return new MaintenanceModeResponse
            {
                IsEnabled = true,
                ActualStart = result.ActualStart,
                PlannedDuration = result.PlannedDuration,
            };
        }

        /// <summary>
        /// Activates maintenance mode.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(StartMaintenanceResponse), (int)HttpStatusCode.OK)]
        public async Task<StartMaintenanceResponse> StartMaintenanceAsync(
            [Required] string who,
            [Required] string reason,
            [Required] TimeSpan plannedDuration)
        {
            var error = await _maintenanceEventService.StartMaintenanceAsync(
                who,
                reason,
                plannedDuration);

            return new StartMaintenanceResponse { Error = error };
        }

        /// <summary>
        /// Deactivates maintenance mode.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public Task StopMaintenanceAsync()
        {
            return _maintenanceEventService.StopMaintenanceAsync();
        }
    }
}
