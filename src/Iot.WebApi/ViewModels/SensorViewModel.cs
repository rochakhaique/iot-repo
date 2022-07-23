using Iot.Domain.Enums;
using System.Collections.Generic;

namespace Iot.WebApi.ViewModels
{
    public class SensorViewModel
    {
        public SensorType SensorType { get; set; }
        public IEnumerable<MeasurementViewModel> Measurements { get; set; }
    }
}
