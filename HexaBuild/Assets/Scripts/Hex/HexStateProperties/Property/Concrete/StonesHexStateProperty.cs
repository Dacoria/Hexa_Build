﻿using System.Collections.Generic;

public class StonesHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Stones;
    public HexSurfaceType Surface => HexSurfaceType.Barren;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Stone;
    public string ButtonImageNameToGetInState => "Stone";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 4);
    public ResourceCostGains RscCostGainsInStatePerTurn =>
        new ResourceCostGains
        {
            Costs = Utils.Rsc(),
            Gains = Utils.Rsc(RscType.Stone, 2)[0],
        };
    public ResourceCostGains RscCostGainsInStatePerAction =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Stone, 2)[0],
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";
    public RscType RscType => RscType.Stone;
    public int RscAvailableInit => 20;
    public HexStateType StateToIfNoMoreRsc => HexStateType.Barren;
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
}