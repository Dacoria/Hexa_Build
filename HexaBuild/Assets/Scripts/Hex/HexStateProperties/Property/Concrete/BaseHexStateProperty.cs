using System.Collections.Generic;

public class BaseHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Base;
    public HexSurfaceType Surface => HexSurfaceExt.BuildingArea();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Base;
    public string ButtonImageNameToGetInState => Type.ToString();
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc();
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { };
}