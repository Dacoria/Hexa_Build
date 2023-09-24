using System;
using System.Collections.Generic;

public class SandHexStateProperty : IHexStateProperty
{    
    public HexStateType Type => HexStateType.Sand;
    public HexSurfaceType Surface => HexSurfaceType.Sand;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Sand_A";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Trees, HexStateType.Wheats };
}