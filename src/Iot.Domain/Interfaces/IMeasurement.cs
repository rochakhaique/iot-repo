using Iot.Domain.Enums;
using System;

namespace Iot.Domain.Interfaces
{
    public interface IMeasurement
    {
        string Device { get; }
        SensorType SensorType { get; }
        DateTime FullDate { get; }
        float Value { get; }
    }
}
