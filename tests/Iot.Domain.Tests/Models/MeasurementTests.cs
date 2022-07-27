using FluentAssertions;
using Iot.Base.Test;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iot.Domain.Tests.Models
{
    [TestClass]
    public class MeasurementTests : TestBase
    {
        [TestMethod]
        [DataRow(SensorType.humidity)]
        [DataRow(SensorType.rainfall)]
        [DataRow(SensorType.temperature)]
        public void Contructor(SensorType sensorType)
        {
            // Act
            IMeasurement sut = new Measurement(DeviceName, sensorType, DateTime, Value);

            // Assert
            sut.Should().NotBeNull();
        }
    }
}
