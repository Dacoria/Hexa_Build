using System.Collections.Generic;

public interface IRscGrowthInState: IRscInState
{
    public List<RscGrowthLevel> RscGrowthLevels { get; }
}