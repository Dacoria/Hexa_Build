using System.Collections.Generic;

public class TreesHexStateProperty : IHexStateProperty, IRscGrowthInState
{
    public HexStateType Type => HexStateType.Trees;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile=> HexObjectOnTileType.Tree;
    public string ButtonImageNameToGetInState => "Tree";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    public List<RscGrowthLevel> RscPerGrowthLevel => RscGrow.CreateList(1, 10, 40, 100);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Woodcutter };
}