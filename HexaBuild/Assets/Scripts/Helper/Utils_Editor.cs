using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Utils
{
    public static bool IsEditor()
    {
        #if UNITY_EDITOR
            return !Application.isPlaying;
        #else
            return false;  
        #endif
    }
}

