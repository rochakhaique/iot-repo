using Iot.Domain.Enums;
using System;

namespace Iot.Domain.Models
{
    public class Measurement
    {
        public Measurement(string device, SensorType sensorType, DateTime fullDate, float value)
        {
            Device = device;
            SensorType = sensorType;
            FullDate = fullDate;
            Value = value;
        }

        public string Device { get; set; }
        public SensorType SensorType { get; set; }
        public DateTime FullDate { get; set; }
        public float Value { get; set; }
    }
}
