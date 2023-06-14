using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static Hex GetHex(this Vector3Int coordinates) => HexGrid.instance.GetHexAt(coordinates);

    public static bool HasRscGains(this IHexStateProperty prop)
    {
        var rscGains = prop.Type.GetProperties() as IRscGainsInState;
        return rscGains != null && rscGains.RscGainsInState.Any();
    }

}