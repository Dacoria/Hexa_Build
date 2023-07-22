using System.Collections.Generic;

public class RscGrowthLevel
{
    public int Level;
    public int RscAvailable;
}

public static class RscGrow
{
    public static List<RscGrowthLevel> CreateList(params int[] args)
    {
        var result = new List<RscGrowthLevel>();
        for (int i = 1; i <= args.Length; i++)
        {
            var item = new RscGrowthLevel { Level = i, RscAvailable = args[i - 1] };
            result.Add(item);
        }

        return result;
    }
}