using System.Collections.Generic;
using UnityEngine;

public static partial class Load
{
    private static List<string> goEnemiesOrObjList = new List<string>
    {
        Statics.LOAD_PATH_GO_PIECES,
        Statics.LOAD_PATH_GO_OBJ_ON_TILE,
        Statics.LOAD_PATH_GO_PLAYER_UTIL,
    };

    private static Dictionary<string, GameObject> __goEnemiesOrObjMap;
    public static Dictionary<string, GameObject> GoEnemiesOrObjMap
    {
        get
        {
            if (__goEnemiesOrObjMap == null)
            {
                __goEnemiesOrObjMap = LoadHelper.CreateGoDict(goEnemiesOrObjList);                
            }

            return __goEnemiesOrObjMap;
        }
    }
}