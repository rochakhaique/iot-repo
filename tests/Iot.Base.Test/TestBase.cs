using AutoMapper;
using Iot.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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

        [TestCleanup]
        public void TearDown()
        {
            MoqRepository?.VerifyAll();
        }

        [TestInitialize]
        public virtual void Setup()
        {
            MoqRepository = new MockRepository(MockBehavior.Default);
            MockMapper = MoqRepository.Create<IMapper>();
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
    }
}
