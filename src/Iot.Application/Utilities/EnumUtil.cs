using System;
using System.Collections.Generic;
using System.Linq;

namespace Iot.Application.Utilities
{
    public static class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>() => Enum.GetValues(typeof(T)).Cast<T>();
    }
}
