using AutoMapper;
using Iot.Domain.Interfaces;
using Iot.WebApi.Responses;
using System.Collections.Generic;
using System.Linq;

namespace Iot.WebApi.Mappings.Devices
{
    public class DeviceBaseMappingProfile : Profile
    {
        public DeviceBaseMappingProfile()
        {
            CreateMap<IEnumerable<IMeasurement>, SensorResponse>()
                .ForMember(dest => dest.SensorType, opt => opt.MapFrom(src => src.FirstOrDefault().SensorType))
                .ForPath(dest => dest.Measurements, opt => opt.MapFrom(src => src));

            CreateMap<IMeasurement, MeasurementResponse>()
                .ForMember(d => d.Date, opt => opt.MapFrom(s => s.FullDate))
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Value));
        }
    }
}
