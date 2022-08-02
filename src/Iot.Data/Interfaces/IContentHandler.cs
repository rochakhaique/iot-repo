using Iot.Data.Dtos;
using System;
using System.Collections.Generic;

namespace Iot.Data.Interfaces
{
    public interface IContentHandlerBase<out TDto> where TDto : IDto
    {
        IEnumerable<TDto> Handle(BinaryData content);
    }

    public interface IMeasurementContentHandler : IContentHandlerBase<MeasurementDto> { }
}
