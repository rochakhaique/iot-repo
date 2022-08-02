using CsvHelper;
using CsvHelper.Configuration;
using Iot.Data.Configs;
using Iot.Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Iot.Data.Handlers
{
    public abstract class ContentHandlerBase<TDto, TCsvConfig> : IContentHandlerBase<TDto>
        where TDto : IDto
        where TCsvConfig : CsvConfig
    {
        protected readonly ILogger<ContentHandlerBase<TDto, TCsvConfig>> _logger;
        protected readonly TCsvConfig _config;

        protected ContentHandlerBase(ILogger<ContentHandlerBase<TDto, TCsvConfig>> logger, TCsvConfig config)
        {
            _logger = logger;
            _config = config;
        }

        public virtual IEnumerable<TDto> Handle(BinaryData content)
        {
            try
            {
                using var reader = new StreamReader(content.ToStream());
                var csvConfiguration = new CsvConfiguration(CultureInfo.GetCultureInfo(_config.CultureInfo))
                {
                    Delimiter = _config.Delimiter,
                    HasHeaderRecord = _config.HasHeader
                };
                using var csv = new CsvReader(reader, csvConfiguration);
                IEnumerable<TDto> records = csv.GetRecords<TDto>().ToList();
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
