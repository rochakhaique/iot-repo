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
using System.Threading.Tasks;

namespace Iot.Application.Tests.Services
{
    [TestClass]
    public class MeasurementServiceTests : TestBase
    {
        private IMeasurementService _sut;
        private Mock<IMeasurementDataService> _mockDataService;
        private Mock<IMeasurementBuilder> _mockBuilder;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            _mockDataService = MoqRepository.Create<IMeasurementDataService>();
            _mockBuilder = MoqRepository.Create<IMeasurementBuilder>();

            _sut = new MeasurementService(_mockBuilder.Object, _mockDataService.Object);
        }

        [TestMethod]
        [DataRow(SensorType.humidity)]
        [DataRow(SensorType.rainfall)]
        [DataRow(SensorType.temperature)]
        public async Task GetMeasurements_SingleSensor_Success(SensorType sensorType)
        {
            // Arrange
            MockGetAsync();

            // Act
            _ = await _sut.GetAsync(DeviceName, DateTime, sensorType);

            // Assert
            // TestBase.TearDown() runs VerifyAll()
        }

        [TestMethod]
        public async Task GetMeasurements_AllSensors_Success()
        {
            // Arrange
            MockGetAsync();

            // Act
            _ = await _sut.GetAllSensorsAsync(DeviceName, DateTime);

            // Assert
            // TestBase.TearDown() runs VerifyAll()
        }

        private void MockGetAsync()
        {
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
        }
    }
}
