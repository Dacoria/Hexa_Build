using System;
using System.Collections.Generic;
using UnityEngine;

public static class AE
{
    public static Action GridLoaded;
    public static Action NewTurn;

    public static Action<Hex> HexStateChanged;
    public static Action<Hex> HexStateLevelChanged;
}
