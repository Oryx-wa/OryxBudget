﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Common
{
    public static class HelperExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
