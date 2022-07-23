using Newtonsoft.Json;

namespace Iot.WebApi.Responses
{
    public abstract class BaseResponse
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
