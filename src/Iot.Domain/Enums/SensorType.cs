using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Iot.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SensorType
    {
        humidity,
        rainfall,
        temperature
    }
}
