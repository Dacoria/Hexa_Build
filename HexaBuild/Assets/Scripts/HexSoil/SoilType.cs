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
        SoilType.Tree => Utils.Rsc(ResourceType.Wood, 1),
        SoilType.Grain => Utils.Rsc(ResourceType.Wood, 2),
        SoilType.Stone => Utils.Rsc(ResourceType.Stone, 2),
        _ => throw new System.NotImplementedException(),
    };

    public static List<ResourceAmount> HarvestCost(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(ResourceType.Energy, 5),
        SoilType.Grain => Utils.Rsc(ResourceType.Energy, 5),
        SoilType.Stone => Utils.Rsc(ResourceType.Energy, 10),
        _ => throw new System.NotImplementedException(),
    };

    public static List<ResourceAmount> HarvestGain(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(ResourceType.Wood, 5),
        SoilType.Grain => Utils.Rsc(ResourceType.Energy, 20),
        SoilType.Stone => Utils.Rsc(ResourceType.Stone, 5),
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