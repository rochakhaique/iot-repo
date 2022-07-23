using Iot.Application.Interfaces;
using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Models;

namespace Iot.Application.Builders
{
    public class MeasurementBuilder : IMeasurementBuilder
    {
        public Measurement Build(string device, SensorType sensorType, MeasurementDto dto)
        {
            Measurement domain = new(device, sensorType, dto.Date, dto.Value);
            return domain;
        }
    }
}
