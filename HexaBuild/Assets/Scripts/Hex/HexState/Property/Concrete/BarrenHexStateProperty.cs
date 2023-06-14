using System.Collections.Generic;

public class BarrenHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Barren;
    public HexSurfaceType? Surface => HexSurfaceExt.Barren();
    public HexObjectOnTileType? ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => Type.ToString();
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc();
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil, HexStateType.Stones };
    public bool ConditionsForfilledToEnterState(Hex hex) => true;
}