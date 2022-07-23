using CsvHelper.Configuration.Attributes;
using System;

namespace Iot.Data.Dtos
{
    public class MeasurementDto
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(1)]
        public float Value { get; set; }
    }
}
