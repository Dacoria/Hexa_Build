using System;
using System.Collections.Generic;

public enum SoilType
{
    Tree,
    Grain,
    Stone
}

public static class HexSoilExtentions
{
    public static List<ResourceAmount> PlantCost(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(RscType.Wood, 1),
        SoilType.Grain => Utils.Rsc(RscType.Wood, 2),
        SoilType.Stone => Utils.Rsc(RscType.Stone, 2),
        _ => throw new System.NotImplementedException(),
    };

    public static List<ResourceAmount> HarvestCost(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(RscType.Energy, 5),
        SoilType.Grain => Utils.Rsc(RscType.Energy, 5),
        SoilType.Stone => Utils.Rsc(RscType.Energy, 10),
        _ => throw new System.NotImplementedException(),
    };

    public static List<ResourceAmount> HarvestGain(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(RscType.Wood, 5),
        SoilType.Grain => Utils.Rsc(RscType.Energy, 20),
        SoilType.Stone => Utils.Rsc(RscType.Stone, 5),
        _ => throw new System.NotImplementedException(),
    };

    public static HexObjectOnTileType GetObjType(this SoilType type) => type switch
    {
        SoilType.Tree => HexObjectOnTileType.Tree,
        SoilType.Grain => HexObjectOnTileType.Grain,
        SoilType.Stone => HexObjectOnTileType.Stone,
        _ => throw new System.NotImplementedException(),
    };

    public static SoilType GetSoilType(this HexObjectOnTileType typeToFind)
    {
        foreach(SoilType soilType in Enum.GetValues(typeof(SoilType)))
        {
            if(soilType.GetObjType() == typeToFind)
            {
                return soilType;
            }
        }

        throw new Exception("");
    }
}