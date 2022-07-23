using Iot.Domain.Models;
using Iot.WebApi.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Iot.WebApi.Mappings.Devices
{
    public class DeviceSingleSensorMappingProfile : DeviceBaseMappingProfile
    {
        public DeviceSingleSensorMappingProfile()
        {
            CreateMap<IEnumerable<Measurement>, DeviceSingleSensorResponse>()
                .ForMember(dest => dest.Device, opt => opt.MapFrom(src => src.FirstOrDefault() != null ? src.First().Device : string.Empty))
                .ForPath(dest => dest.Sensor, opt => opt.MapFrom(src => src));
        }
    }
}
