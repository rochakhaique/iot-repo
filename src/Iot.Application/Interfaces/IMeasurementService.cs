using Iot.Domain.Enums;
using Iot.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iot.Application.Interfaces
{
    public interface IMeasurementService
    {
        Task<IEnumerable<Measurement>> GetAsync(string deviceId, DateTime date, SensorType sensorType);
        Task<IEnumerable<Measurement>> GetAllSensorsAsync(string deviceId, DateTime date);
    }
}
