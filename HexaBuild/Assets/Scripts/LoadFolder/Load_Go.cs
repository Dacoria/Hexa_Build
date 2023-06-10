using System.Collections.Generic;
using UnityEngine;

public static partial class Load
{
    private static List<string> goObjList = new List<string>
    {
        Statics.LOAD_PATH_GO_OBJ_ON_TILE,
    };

    private static Dictionary<string, GameObject> __goEnemiesOrObjMap;
    public static Dictionary<string, GameObject> GoEnemiesOrObjMap
    {
        get
        {
            if (__goEnemiesOrObjMap == null)
            {
                __goEnemiesOrObjMap = LoadHelper.CreateGoDict(goObjList);                
            }

            return __goEnemiesOrObjMap;
        }
    }
}