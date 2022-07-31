using System.Collections.Generic;

namespace Iot.WebApi.Responses
{
    public class DeviceMultipleSensorsResponse : BaseResponse
    {
        public string Device { get; set; }
        public IEnumerable<SensorResponse> Sensors { get; set; }
    }
}
