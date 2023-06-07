using System;

public static partial class Utils
{
    public static double MsBetweenNow(this DateTime dateTime) => (DateTime.Now - dateTime).TotalMilliseconds;
}