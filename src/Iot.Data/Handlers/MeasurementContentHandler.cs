using CsvHelper;
using CsvHelper.Configuration;
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

        public MeasurementContentHandler(ILogger<MeasurementContentHandler> logger)
        {
            _logger = logger;
        }

        public IEnumerable<MeasurementDto> Handle(BinaryData content)
        {
            try
            {
                IEnumerable<MeasurementDto> records;
                using (var reader = new StreamReader(content.ToStream()))
                {
                    var csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU")) { Delimiter = ";", HasHeaderRecord = false };
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
