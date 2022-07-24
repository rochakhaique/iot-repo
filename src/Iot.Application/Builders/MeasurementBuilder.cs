using Iot.Application.Interfaces;
using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;

namespace Iot.Application.Builders
{
    public class MeasurementBuilder : IMeasurementBuilder
    {
        public IMeasurement Build(string device, SensorType sensorType, MeasurementDto dto)
        {
            IMeasurement domain = new Measurement(device, sensorType, dto.Date, dto.Value);
            return domain;
        }
    }
}
