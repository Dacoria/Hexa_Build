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
        BuildingType.Woodcutter => Utils.Rsc(ResourceType.Wood, 1),
        BuildingType.StoneMiner => Utils.Rsc(ResourceType.Wood, 1, ResourceType.Stone, 1),
        _ => throw new System.NotImplementedException(),
    };
}