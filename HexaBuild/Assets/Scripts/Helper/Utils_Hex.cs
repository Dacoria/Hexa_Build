using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static Hex GetHex(this Vector3Int coordinates) => HexGrid.instance.GetHexAt(coordinates);
           
}