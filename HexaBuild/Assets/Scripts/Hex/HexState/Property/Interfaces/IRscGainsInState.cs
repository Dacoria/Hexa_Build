using System.Collections.Generic;

public interface IRscGainsInState: IRscInState
{
    public ResourceCostGains RscCostGainsInStatePerTurn { get; }
    public ResourceCostGains RscCostGainsInStatePerAction { get; }
    public string ButtonImageNameToGetRsc { get; }
}