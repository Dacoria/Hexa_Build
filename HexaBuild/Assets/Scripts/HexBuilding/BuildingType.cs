using System.Collections.Generic;

public enum BuildingType
{
    Woodcutter,
    StoneMiner,
}

public static class HexBuildingExtentions
{
    public static List<ResourceAmount> Cost(this BuildingType type) => type switch
    {
        BuildingType.Woodcutter => Utils.Rsc(RscType.Wood, 1),
        BuildingType.StoneMiner => Utils.Rsc(RscType.Wood, 1, RscType.Stone, 1),
        _ => throw new System.NotImplementedException(),
    };
}