using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using System;

namespace Iot.Domain.Models
{
    public class Measurement : IMeasurement
    {
        public Measurement(string device, SensorType sensorType, DateTime fullDate, decimal value)
        {
            Device = device;
            SensorType = sensorType;
            FullDate = fullDate;
            Value = value;
        }

        public string Device { get; private set; }
        public SensorType SensorType { get; private set; }
        public DateTime FullDate { get; private set; }
        public decimal Value { get; private set; }
    }
}
