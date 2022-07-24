using FluentAssertions;
using Iot.Application.Builders;
using Iot.Application.Interfaces;
using Iot.Base.Test;
using Iot.Data.Dtos;
using Iot.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Iot.Application.Tests.Builders
{
    [TestClass]
    public class MeasurementBuilderTests : TestBase
    {
        private IMeasurementBuilder _subject;
        private Mock<MeasurementDto> _mockMeasurementDto;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            _mockMeasurementDto = MoqRepository.Create<MeasurementDto>();

            _subject = new MeasurementBuilder();
        }

        [TestMethod]
        public void Build_Succeed()
        {
            // Arrange
            MeasurementDto mockDto = _mockMeasurementDto.Object;
            Measurement expected = new(DeviceName, SensorType, mockDto.Date, mockDto.Value);

            // Act
            Measurement actual = _subject.Build(DeviceName, SensorType, _mockMeasurementDto.Object);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
