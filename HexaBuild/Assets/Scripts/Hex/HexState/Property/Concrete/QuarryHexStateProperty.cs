﻿using System.Collections.Generic;

public class QuarryHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Quarry;
    public HexSurfaceType? Surface => HexSurfaceType.Barren;
    public HexObjectOnTileType? ObjectOnTile => HexObjectOnTileType.Quarry;
    public string ButtonImageNameToGetInState => "Take";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy,5, RscType.Wood, 6);
    public List<ResourceAmount> RscGainsInState => Utils.Rsc(RscType.Stone, 5);
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
    public bool ConditionsForfilledToEnterState(Hex hex) => true;
}