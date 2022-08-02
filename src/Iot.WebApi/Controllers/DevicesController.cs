using AutoMapper;
using Iot.Application.Interfaces;
using Iot.Domain.Enums;
using Iot.WebApi.Mappings.Devices;
using Iot.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Iot.WebApi.Controllers
{
    /// <summary>
    /// Devices Controller
    /// </summary>
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DevicesController : BaseController
    {
        private readonly IMeasurementService _measurementService;

        public DevicesController(ILogger<DevicesController> logger, IMapper mapper, IMeasurementService measurementService) : base(logger, mapper)
        {
            _measurementService = measurementService;
        }

        /// <summary>
        /// Collect all of the measurements for one day, one sensor type, and one unit.
        /// </summary>
        /// <param name="deviceId">Device which generated the measurements</param>
        /// <param name="date">Date following the format: yyyy-MM-dd</param>
        /// <param name="sensorType">Sensor type ("humidity", "rainfall", "temperature")</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/devices/dockan/data/2019-01-10/temperature
        ///
        /// </remarks>
        /// <returns>DeviceSingleSensorResponse object</returns>
        [HttpGet("{deviceId}/data/{date}/{sensorType}")]
        [ProducesResponseType(typeof(DeviceSingleSensorResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> GetAsync([FromRoute] string deviceId, [FromRoute] DateTime date, [FromRoute] SensorType sensorType)
        {
            var measurements = await _measurementService.GetAsync(deviceId, date, sensorType);
            var response = Mapper.Map<DeviceSingleSensorResponse>(measurements);
            return Ok(response);
        }

        /// <summary>
        /// Collect all data points for one unit and one day.
        /// </summary>
        /// <param name="deviceId">Device which generated the measurements</param>
        /// <param name="date">Date following the format: yyyy-MM-dd</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/devices/dockan/data/2019-01-10/
        ///
        /// </remarks>
        /// <returns>DeviceMultipleSensorsResponse object</returns>
        [HttpGet("{deviceId}/data/{date}")]
        [ProducesResponseType(typeof(DeviceMultipleSensorsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> GetAsync([FromRoute] string deviceId, [FromRoute] DateTime date)
        {
            var measurements = await _measurementService.GetAllSensorsAsync(deviceId, date);
            var response = DeviceMultipleSensorsMappingProfile.Map(deviceId, measurements);
            return Ok(response);
        }
    }
}
