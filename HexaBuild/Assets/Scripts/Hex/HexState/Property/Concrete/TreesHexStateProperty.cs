using System.Collections.Generic;

public class TreesHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Trees;
    public HexSurfaceType? Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType? ObjectOnTile=> HexObjectOnTileType.Tree;
    public string ButtonImageNameToGetInState => "Tree";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Woodcutter };
    public bool ConditionsForfilledToEnterState(Hex hex) => true;
}