using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Iot.WebApi.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Iot.WebApi.Mappings.Devices
{
    public static class DeviceMultipleSensorsMappingProfile
    {
        public static DeviceMultipleSensorsResponse Map(string deviceId, IEnumerable<IMeasurement> measurements)
        {
            var sensorsVM = new List<SensorResponse>();

            foreach (SensorType sensorType in measurements.Select(m => m.SensorType).Distinct())
            {
                var measurementsVM = new List<MeasurementResponse>();
                foreach (var measurement in measurements.Where(m => m.SensorType == sensorType))
                {
                    measurementsVM.Add(new MeasurementResponse() { Date = measurement.FullDate, Value = measurement.Value });
                }
                sensorsVM.Add(new SensorResponse() { SensorType = sensorType, Measurements = measurementsVM });
            }

            var response = new DeviceMultipleSensorsResponse()
            {
                Device = deviceId,
                Sensors = sensorsVM
            };
            return response;
        }
    }
}
