using System.Collections.Generic;
using System.Linq;

public class TransparantHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Transparent;
    public HexSurfaceType? Surface => HexSurfaceExt.Transparant();
    public HexObjectOnTileType? ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Transparent?!";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc();
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
    public bool ConditionsForfilledToEnterState(Hex hex) => HexGrid.instance.GetNeighboursFor(hex.HexCoordinates, range: 1).Any();
}