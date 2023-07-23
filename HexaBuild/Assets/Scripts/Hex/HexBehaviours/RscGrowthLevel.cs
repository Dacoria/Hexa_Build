using System.Collections.Generic;

public class RscGrowthLevel
{
    public int Level;
    public int CountRscAvailable;
}

public static class RscGrow
{
    public static List<RscGrowthLevel> CreateList(params int[] resourceCountPerLevel)
    {
        var levelsResult = new List<RscGrowthLevel>();
        for (int i = 1; i <= resourceCountPerLevel.Length; i++)
        {
            var item = new RscGrowthLevel { Level = i, CountRscAvailable = resourceCountPerLevel[i - 1] };
            levelsResult.Add(item);
        }

        return levelsResult;
    }
}