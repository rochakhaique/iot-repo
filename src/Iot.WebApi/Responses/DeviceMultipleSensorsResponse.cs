using Iot.WebApi.ViewModels;
using System.Collections.Generic;

namespace Iot.WebApi.Responses
{
    public class DeviceMultipleSensorsResponse : BaseResponse
    {
        public string Device { get; set; }
        public IEnumerable<SensorViewModel> Sensors { get; set; }
    }
}
