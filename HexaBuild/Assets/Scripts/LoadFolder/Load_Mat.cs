using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static partial class Load
{
    private static List<string> materialTileList = new List<string>
    {
        Statics.LOAD_PATH_MATERIAL_TILE_TYPES
    };

    private static Dictionary<string, Material> __materialTileMap;
    public static Dictionary<string, Material> MaterialTileMap
    {
        get
        {
            if (__materialTileMap == null || !Application.isPlaying)
                __materialTileMap = LoadHelper.CreateMaterialDict(materialTileList);
            
            return __materialTileMap;
        }
    }

    private static List<string> materialColorList = new List<string>
    {
        Statics.LOAD_PATH_MATERIAL_COLORS,
    };

    private static Dictionary<string, Material> __materialColorMap;
    public static Dictionary<string, Material> MaterialColorMap
    {
        get
        {
            if (__materialColorMap == null)
                __materialColorMap = LoadHelper.CreateMaterialDict(materialColorList);

            return __materialColorMap;
        }
    }

    public static Material GetMaterial(this HighlightColorType colorType) =>
        MaterialColorMap.Single(x => x.Key == colorType.ToString()).Value;

}