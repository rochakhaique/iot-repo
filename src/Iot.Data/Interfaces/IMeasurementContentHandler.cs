using Iot.Data.Dtos;
using System;
using System.Collections.Generic;

namespace Iot.Data.Interfaces
{
    public interface IMeasurementContentHandler
    {
        IEnumerable<MeasurementDto> Handle(BinaryData content);
    }
}
