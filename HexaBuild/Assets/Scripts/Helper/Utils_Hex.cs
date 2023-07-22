using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static Hex GetHex(this Vector3Int coordinates) => HexGrid.instance.GetHexAt(coordinates);

    public static bool HasRscGains(this IHexStateProperty prop)
    {
        var rscGains = prop.Type.Props() as IRscGainsInState;
        return rscGains != null;
    }

    public static bool HasRscGrowth(this IHexStateProperty prop)
    {
        var rscGrowth = prop.Type.Props() as IRscGrowthInState;
        return rscGrowth != null;
    }

}