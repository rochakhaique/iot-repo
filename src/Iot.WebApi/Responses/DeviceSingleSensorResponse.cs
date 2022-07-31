namespace Iot.WebApi.Responses
{
    public class DeviceSingleSensorResponse : BaseResponse
    {
        public string Device { get; set; }
        public SensorResponse Sensor { get; set; }
    }
}
