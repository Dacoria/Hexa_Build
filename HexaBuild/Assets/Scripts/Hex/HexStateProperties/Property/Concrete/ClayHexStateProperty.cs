using System;
using System.Collections.Generic;

public class ClayHexStateProperty : IHexStateProperty
{    
    public HexStateType Type => HexStateType.Clay;
    public HexSurfaceType Surface => HexSurfaceType.Clay;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Clay_A";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Stone, 10);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
    //Want to add something like next state flame with bricks or pottery
}