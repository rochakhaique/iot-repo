using Iot.Application.Interfaces;
using Iot.Application.Services;
using Iot.Base.Test;
using Iot.Data.Dtos;
using Iot.Data.Interfaces;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Iot.Application.Tests.Services
{
    [TestClass]
    public class MeasurementServiceTests : TestBase
    {
        private IMeasurementService _subject;
        private Mock<IMeasurementDataService> _mockDataService;
        private Mock<IMeasurementBuilder> _mockBuilder;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            _mockDataService = MoqRepository.Create<IMeasurementDataService>();
            _mockBuilder = MoqRepository.Create<IMeasurementBuilder>();

            _subject = new MeasurementService(_mockBuilder.Object, _mockDataService.Object);
        }

        [TestMethod]
        [DataRow(SensorType.humidity)]
        [DataRow(SensorType.rainfall)]
        [DataRow(SensorType.temperature)]
        public void GetMeasurements_SingleSensor_Success(SensorType sensorType)
        {
            // Arrange
            _mockDataService
                .Setup(ds => ds.GetAsync(
                    It.IsAny<string>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<SensorType>()))
                .ReturnsAsync(GetMeasurementsDtos(5));
            _mockBuilder
                .Setup(b => b.Build(
                    It.IsAny<string>(),
                    It.IsAny<SensorType>(),
                    It.IsAny<MeasurementDto>()))
                .Returns(MoqRepository.Create<IMeasurement>().Object);

            // Act
            var actual = _subject.GetAsync(DeviceName, DateTime, sensorType);

            // Assert
            // TearDown runs VerifyAll()
        }

        [TestMethod]
        public void GetMeasurements_AllSensors_Success()
        {
            // Arrange
            _mockDataService
                .Setup(ds => ds.GetAsync(
                    It.IsAny<string>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<SensorType>()))
                .ReturnsAsync(GetMeasurementsDtos(5));
            _mockBuilder
                .Setup(b => b.Build(
                    It.IsAny<string>(),
                    It.IsAny<SensorType>(),
                    It.IsAny<MeasurementDto>()))
                .Returns(MoqRepository.Create<IMeasurement>().Object);

            // Act
            var actual = _subject.GetAllSensorsAsync(DeviceName, DateTime);

            // Assert
            // TearDown runs VerifyAll()
        }
    }
}
