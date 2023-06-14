using System.Collections.Generic;
using System.Linq;

public class TransparantHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Transparent;
    public HexSurfaceType Surface => HexSurfaceExt.Transparant();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.None;
    public string ButtonImageNameToGetInState => "Transparent";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc();
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
    bool IHexStateProperty.ConditionsForfilledToLeaveState(Hex hex)
    {
        return HexGrid.instance.GetNeighboursFor(hex.HexCoordinates, range: 1).Any();
    }
}