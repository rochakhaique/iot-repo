using Iot.Domain.Enums;
using System.Collections.Generic;

namespace Iot.WebApi.Responses
{
    public class SensorResponse
    {
        public SensorType SensorType { get; set; }
        public IEnumerable<MeasurementResponse> Measurements { get; set; }
    }
}
