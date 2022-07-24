using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iot.Application.Interfaces
{
    public interface IMeasurementService
    {
        Task<IEnumerable<IMeasurement>> GetAsync(string deviceId, DateTime date, SensorType sensorType);
        Task<IEnumerable<IMeasurement>> GetAllSensorsAsync(string deviceId, DateTime date);
    }
}
