using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Models;

namespace Iot.Application.Interfaces
{
    public interface IMeasurementBuilder
    {
        Measurement Build(string device, SensorType sensorType, MeasurementDto dto);
    }
}
