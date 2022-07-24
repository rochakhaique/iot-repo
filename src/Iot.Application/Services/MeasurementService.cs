using Iot.Application.Interfaces;
using Iot.Application.Utilities;
using Iot.Data.Dtos;
using Iot.Data.Interfaces;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Iot.Application.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementBuilder _measurementBuilder;
        private readonly IMeasurementDataService _measurementDataService;

        public MeasurementService(IMeasurementBuilder measurementBuilder, IMeasurementDataService measurementDataService)
        {
            _measurementBuilder = measurementBuilder;
            _measurementDataService = measurementDataService;
        }

        public async Task<IEnumerable<IMeasurement>> GetAsync(string deviceId, DateTime date, SensorType sensorType)
        {
            var dtos = await _measurementDataService.GetAsync(deviceId, date, sensorType);   
            return dtos.Select(dto => _measurementBuilder.Build(deviceId, sensorType, dto)).ToList();
        }

        public async Task<IEnumerable<IMeasurement>> GetAllSensorsAsync(string deviceId, DateTime date)
        {
            var measurements = new List<IMeasurement>();
            foreach (SensorType sensorType in EnumUtil.GetValues<SensorType>())
            {
                measurements.AddRange(await GetAsync(deviceId, date, sensorType));
            }
            return measurements;

        }
    }
}
