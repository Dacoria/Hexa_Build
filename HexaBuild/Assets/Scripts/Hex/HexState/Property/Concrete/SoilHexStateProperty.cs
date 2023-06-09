﻿using System;
using System.Collections.Generic;

public class SoilHexStateProperty : IHexStateProperty
{    
    public HexStateType Type => HexStateType.Soil;
    public HexSurfaceType Surface => HexSurfaceType.Sand_Dirt;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Sand_Dirt";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Trees, HexStateType.Wheats };
}