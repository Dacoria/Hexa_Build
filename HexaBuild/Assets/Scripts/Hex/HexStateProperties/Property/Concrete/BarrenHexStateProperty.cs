using System.Collections.Generic;

public class BarrenHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Barren;
    public HexSurfaceType Surface => HexSurfaceExt.Barren();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Barren";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc();
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> {HexStateType.Soil, HexStateType.Sand, HexStateType.Stones, HexStateType.Water };
}