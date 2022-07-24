using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;

namespace Iot.Application.Interfaces
{
    public interface IMeasurementBuilder
    {
        IMeasurement Build(string device, SensorType sensorType, MeasurementDto dto);
    }
}
