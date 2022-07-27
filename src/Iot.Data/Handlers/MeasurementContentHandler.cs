using CsvHelper;
using CsvHelper.Configuration;
using Iot.Data.Configs;
using Iot.Data.Dtos;
using Iot.Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Iot.Data.Handlers
{
    public class MeasurementContentHandler : IMeasurementContentHandler
    {
        private readonly ILogger<MeasurementContentHandler> _logger;
        private readonly MeasurementContentHandlerConfig _config;

        public MeasurementContentHandler(ILogger<MeasurementContentHandler> logger, MeasurementContentHandlerConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public IEnumerable<MeasurementDto> Handle(BinaryData content)
        {
            try
            {
                IEnumerable<MeasurementDto> records;
                using (var reader = new StreamReader(content.ToStream()))
                {
                    var csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo(_config.CsvConfig.CultureInfo))
                    {
                        Delimiter = _config.CsvConfig.Delimiter,
                        HasHeaderRecord = _config.CsvConfig.HasHeader
                    };
                    using var csv = new CsvReader(reader, csvConfiguration);
                    records = csv.GetRecords<MeasurementDto>().ToList();
                }

                return records;
            }
            catch (CsvHelperException ex)
            {
                _logger.LogError(ex, "Error on Csv parsing.");
                throw;
            }
        }
    }
}
