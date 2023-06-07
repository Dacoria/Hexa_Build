using System.Collections.Generic;
using UnityEngine;

public static partial class Rsc
{
    private static List<string> goEnemiesOrObjList = new List<string>
    {
        Statics.RESOURCE_PATH_GO_PIECES,
        Statics.RESOURCE_PATH_GO_OBJ_ON_TILE,
        Statics.RESOURCE_PATH_GO_PLAYER_UTIL,
    };

    private static Dictionary<string, GameObject> __goEnemiesOrObjMap;
    public static Dictionary<string, GameObject> GoEnemiesOrObjMap
    {
        get
        {
            if (__goEnemiesOrObjMap == null)
            {
                __goEnemiesOrObjMap = RscHelper.CreateGoDict(goEnemiesOrObjList);                
            }

            return __goEnemiesOrObjMap;
        }
    }          

    private static List<string> goGuiList = new List<string>
    {
        Statics.RESOURCE_PATH_GO_GUI
    };

    private static Dictionary<string, GameObject> __goGuiMap;
    public static Dictionary<string, GameObject> GoGuiMap
    {
        get
        {
            if (__goGuiMap == null)
            {
                __goGuiMap = RscHelper.CreateGoDict(goGuiList);                
            }

            return __goGuiMap;
        }
    }
}