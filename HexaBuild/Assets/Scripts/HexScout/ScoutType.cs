using System.Collections.Generic;

public enum ScoutType
{
    Discover
}

public static class HexScoutExtentions
{
    public static List<ResourceAmount> Cost(this ScoutType type) => type switch
    {
        ScoutType.Discover => Utils.Rsc(RscType.Energy, 10),
        _ => throw new System.NotImplementedException(),
    };
}