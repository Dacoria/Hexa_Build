using System;
using System.Collections.Generic;

public class WaterHexStateProperty : IHexStateProperty
{    
    public HexStateType Type => HexStateType.Water;
    public HexSurfaceType Surface => HexSurfaceType.Water;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Water_A";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Mana, 5);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Clay };
}