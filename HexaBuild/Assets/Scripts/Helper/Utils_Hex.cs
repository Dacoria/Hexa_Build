using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static Hex GetHex(this Vector3Int coordinates) => HexGrid.instance.GetHexAt(coordinates);

    public static bool HasRscGains(this IHexStateProperty prop)
    {
        var rscGainsState = prop.Type.Props() as IRscGainsInState;
        return rscGainsState != null;
    }

    public static bool HasRscGrowth(this IHexStateProperty prop)
    {
        var rscGrowthState = prop.Type.Props() as IRscGrowthInState;
        return rscGrowthState != null;
    }

    public static bool HasRsc(this IHexStateProperty prop)
    {
        var rscState = prop.Type.Props() as IRscInState;
        return rscState != null;
    }
}