using System.Collections.Generic;

public class StonesHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Stones;
    public HexSurfaceType Surface => HexSurfaceType.Barren;
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Stone;
    public string ButtonImageNameToGetInState => "Stone";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 4);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Quarry };
}