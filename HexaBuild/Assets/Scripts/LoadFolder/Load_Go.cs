using System.Collections.Generic;
using UnityEngine;

public static partial class Load
{
    private static List<string> goList = new List<string>
    {
        Statics.LOAD_PATH_GO_OBJ_ON_TILE,
    };

    private static Dictionary<string, GameObject> __goMap;
    public static Dictionary<string, GameObject> GoMap
    {
        get
        {
            if (__goMap == null)
            {
                __goMap = LoadHelper.CreateGoDict(goList);                
            }

            return __goMap;
        }
    }
}