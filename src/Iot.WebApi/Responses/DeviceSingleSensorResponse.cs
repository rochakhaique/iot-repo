using Iot.WebApi.ViewModels;

namespace Iot.WebApi.Responses
{
    public class DeviceSingleSensorResponse : BaseResponse
    {
        public string Device { get; set; }
        public SensorViewModel Sensor { get; set; }
    }
}
