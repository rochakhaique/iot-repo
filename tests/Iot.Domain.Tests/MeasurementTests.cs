using FluentAssertions;
using Iot.Domain.Enums;
using Iot.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Iot.Domain.Tests
{
    [TestClass]
    public class MeasurementTests
    {
        private readonly string _deviceName = "MEASUREMENT_DEVICE_NAME";
        private readonly DateTime _dateTime = new(2022, 07, 23, 21, 30, 0, 0);
        private readonly float _value = Convert.ToInt64(new Random().NextDouble());

        [TestMethod]
        [DataRow(SensorType.humidity)]
        [DataRow(SensorType.rainfall)]
        [DataRow(SensorType.temperature)]
        public void Contructor(SensorType sensorType)
        {
            // Act
            Measurement subject = new(_deviceName, sensorType, _dateTime, _value);

            // Assert
            subject.Should().NotBeNull();
        }
    }
}
