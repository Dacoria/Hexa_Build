using System.Collections.Generic;

public class TreesHexStateProperty : IHexStateProperty, IRscGrowthInState, IRscGainsInState
{
    public HexStateType Type => HexStateType.Trees;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile=> HexObjectOnTileType.Tree;
    public string ButtonImageNameToGetInState => "Tree";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    public List<RscGrowthLevel> RscPerGrowthLevel => RscGrow.CreateList(1, 10, 40, 100);

    public ResourceCostGains RscCostGainsInState =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Wood, 2),
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";

    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}