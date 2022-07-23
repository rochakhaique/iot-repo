using Iot.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace Iot.Data.Interfaces
{
    public interface IMeasurementRepository
    {
        Task<BinaryData> GetContentAsync(string deviceId, DateTime date, SensorType sensorType);
    }
}
