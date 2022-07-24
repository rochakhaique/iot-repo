using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Iot.WebApi.Responses;
using Iot.WebApi.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Iot.WebApi.Mappings.Devices
{
    public static class DeviceMultipleSensorsMappingProfile
    {
        public static DeviceMultipleSensorsResponse Map(string deviceId, IEnumerable<IMeasurement> measurements)
        {
            var sensorsVM = new List<SensorViewModel>();

            foreach (SensorType sensorType in measurements.Select(m => m.SensorType).Distinct())
            {
                var measurementsVM = new List<MeasurementViewModel>();
                foreach (var measurement in measurements.Where(m => m.SensorType == sensorType))
                {
                    measurementsVM.Add(new MeasurementViewModel() { Date = measurement.FullDate, Value = measurement.Value });
                }
                sensorsVM.Add(new SensorViewModel() { SensorType = sensorType, Measurements = measurementsVM });
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
