using Iot.Application.Interfaces;
using Iot.Application.Utilities;
using Iot.Data.Interfaces;
using Iot.Domain.Enums;
using Iot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Measurement>> GetAsync(string deviceId, DateTime date, SensorType sensorType)
        {
            var dtos = await _measurementDataService.GetAsync(deviceId, date, sensorType);
            return dtos.Select(dto => _measurementBuilder.Build(deviceId, sensorType, dto));
        }

        public async Task<IEnumerable<Measurement>> GetAllSensorsAsync(string deviceId, DateTime date)
        {
            List<Measurement> measurements = new();
            foreach (SensorType sensorType in EnumUtil.GetValues<SensorType>())
            {
                measurements.AddRange(await GetAsync(deviceId, date, sensorType));
            }
            return measurements;

        }
    }
}
