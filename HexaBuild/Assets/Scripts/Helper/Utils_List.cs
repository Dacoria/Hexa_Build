using System;
using System.Collections.Generic;
using System.Linq;

public static partial class Utils
{
    public static bool In<T>(this T val, params T[] values) where T : struct => values.Contains(val);
    public static List<T> List<T>(this Array array)
    {
        var res = new List<T>();
        foreach(T item in array)
        {
            res.Add(item);
        }

        return res;
    }
}