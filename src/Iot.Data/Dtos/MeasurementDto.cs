using CsvHelper.Configuration.Attributes;
using Iot.Data.Interfaces;
using System;

namespace Iot.Data.Dtos
{
    public class MeasurementDto : IDto
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(1)]
        public decimal Value { get; set; }
    }
}
