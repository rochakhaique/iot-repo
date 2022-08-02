using Iot.Data.Configs;
using Iot.Data.Dtos;
using Iot.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace Iot.Data.Handlers
{
    public class MeasurementContentHandler : ContentHandlerBase<MeasurementDto, MeasurementCsvConfig>, IMeasurementContentHandler
    {
        public MeasurementContentHandler(ILogger<MeasurementContentHandler> logger, MeasurementCsvConfig config) : base(logger, config) { }
    }
}
