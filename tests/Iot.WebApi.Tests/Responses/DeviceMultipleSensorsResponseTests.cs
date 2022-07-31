using FluentAssertions;
using Iot.Base.Test;
using Iot.WebApi.Responses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Iot.WebApi.Tests.Responses
{
    [TestClass]
    public class DeviceMultipleSensorsResponseTests : TestBase
    {
        [TestMethod]
        public void ToString_Success()
        {
            // Arrange
            var expected = @"{""Device"":""DEVICE_NAME"",""Sensors"":[{""SensorType"":""temperature"",""Measurements"":[{""Date"":""2022-07-23T21:30:00"",""Value"":12.34},{""Date"":""2022-07-23T21:30:00"",""Value"":12.34},{""Date"":""2022-07-23T21:30:00"",""Value"":12.34}]}]}";

            var response = new DeviceMultipleSensorsResponse()
            {
                Device = DeviceName,
                Sensors = new List<SensorResponse>()
                {
                    new SensorResponse()
                    {
                        SensorType = SensorType,
                        Measurements = GetMeasurementsesponses(3)
                    }
                }
            };

            // Act
            string actual = response.ToString();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
