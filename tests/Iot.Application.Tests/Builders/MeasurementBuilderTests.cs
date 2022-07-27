using FluentAssertions;
using Iot.Application.Builders;
using Iot.Application.Interfaces;
using Iot.Base.Test;
using Iot.Data.Dtos;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Iot.Application.Tests.Builders
{
    [TestClass]
    public class MeasurementBuilderTests : TestBase
    {
        private IMeasurementBuilder _sut;
        private Mock<MeasurementDto> _mockDto;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            _mockDto = MoqRepository.Create<MeasurementDto>();

            _sut = new MeasurementBuilder();
        }

        [TestMethod]
        public void Build_Succeed()
        {
            // Arrange
            MeasurementDto mockDto = _mockDto.Object;
            IMeasurement expected = new Measurement(DeviceName, SensorType, mockDto.Date, mockDto.Value);

            // Act
            IMeasurement actual = _sut.Build(DeviceName, SensorType, _mockDto.Object);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
