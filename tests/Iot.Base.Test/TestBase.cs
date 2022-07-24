using AutoMapper;
using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Iot.Base.Test
{
    [TestClass]
    public abstract class TestBase
    {
        protected readonly string DeviceName = "MEASUREMENT_DEVICE_NAME";
        protected readonly SensorType SensorType = SensorType.temperature;
        protected readonly DateTime DateTime = new(2022, 07, 23, 21, 30, 0, 0);
        protected readonly float Value = Convert.ToInt64(new Random().NextDouble());

        protected MockRepository MoqRepository { get; private set; }
        protected Mock<IMapper> MockMapper { get; private set; }

        [TestInitialize]
        public virtual void Setup()
        {
            MoqRepository = new MockRepository(MockBehavior.Default);
            MockMapper = MoqRepository.Create<IMapper>();
        }

        [TestCleanup]
        public void TearDown()
        {
            MoqRepository?.VerifyAll();
        }

        public static Mock<ILogger<T>> BaseSetupAnyLogger<T>()
        {
            var logger = new Mock<ILogger<T>>();

            logger
                .Setup(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            return logger;
        }

        private IEnumerable<T> GetObjects<T>(int n) where T : class
        {
            var objects = new List<T>(capacity: 5);
            for (int i = 0; i < n; i++)
            {
                objects.Add(MoqRepository.Create<T>().Object);
            }
            return objects;
        }

        public IEnumerable<IMeasurement> GetMeasurements(int n) => GetObjects<IMeasurement>(n);
        public IEnumerable<MeasurementDto> GetMeasurementsDtos(int n) => GetObjects<MeasurementDto>(n);
    }
}
