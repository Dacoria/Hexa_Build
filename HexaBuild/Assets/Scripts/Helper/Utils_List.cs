using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Utils
{
    public static bool In<T>(this T val, params T[] values) where T : struct => values.Contains(val);
}