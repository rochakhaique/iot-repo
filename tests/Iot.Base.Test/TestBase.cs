using AutoMapper;
using Iot.Data.Dtos;
using Iot.Domain.Enums;
using Iot.Domain.Interfaces;
using Iot.Domain.Models;
using Iot.WebApi.ViewModels;
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
        protected readonly string DeviceName = "DEVICE_NAME";
        protected readonly SensorType SensorType = SensorType.temperature;
        protected readonly DateTime DateTime = new(2022, 07, 23, 21, 30, 0, 0);
        protected readonly float Value = 12.34f;

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

        protected static Mock<ILogger<T>> BaseSetupAnyLogger<T>()
        {
            var logger = new Mock<ILogger<T>>();

            logger.Setup(x =>
                x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<object>(),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<object, Exception, string>>()));

            return logger;
        }

        protected IEnumerable<IMeasurement> GetMeasurements(int n) => GetObjects(n, createObject: () => new Measurement(DeviceName, SensorType, DateTime, Value));
        protected IEnumerable<MeasurementDto> GetMeasurementsDtos(int n) => GetObjects(n, createObject: () => new MeasurementDto() { Date = DateTime, Value = Value });
        protected IEnumerable<MeasurementViewModel> GetMeasurementsVMs(int n) => GetObjects(n, createObject: () => new MeasurementViewModel() { Date = DateTime, Value = Value });

        private IEnumerable<T> GetObjects<T>(int n, Func<T> createObject) where T : class
        {
            var objects = new List<T>(capacity: n);
            for (int i = 0; i < n; i++)
            {
                objects.Add(createObject());
            }
            return objects;
        }
    }
}
