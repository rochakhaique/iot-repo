using Iot.Data.Dtos;
using Iot.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Iot.Data.Interfaces
{
    public interface IMeasurementDataService
    {
        Task<IEnumerable<MeasurementDto>> GetAsync(string deviceId, DateTime date, SensorType sensorType);
    }
}
