using System;

namespace Iot.WebApi.Responses
{
    public class MeasurementResponse
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
