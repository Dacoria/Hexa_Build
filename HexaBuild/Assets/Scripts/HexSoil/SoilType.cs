using System.Collections.Generic;

public enum SoilType
{
    Tree,
    Grain,
    Stone
}

public static class HexSoilExtentions
{
    public static List<ResourceAmount> Cost(this SoilType type) => type switch
    {
        SoilType.Tree => Utils.Rsc(ResourceType.Wood, 1, ResourceType.Energy, 5),
        SoilType.Grain => Utils.Rsc(ResourceType.Wood, 2, ResourceType.Energy, 5),
        SoilType.Stone => Utils.Rsc(ResourceType.Stone, 2, ResourceType.Energy, 5),
        _ => throw new System.NotImplementedException(),
    };
}