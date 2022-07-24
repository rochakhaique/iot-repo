using FluentAssertions;
using Iot.Base.Test;
using Iot.Domain.Enums;
using Iot.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            Measurement subject = new(DeviceName, sensorType, DateTime, Value);

            // Assert
            subject.Should().NotBeNull();
        }
    }
}
