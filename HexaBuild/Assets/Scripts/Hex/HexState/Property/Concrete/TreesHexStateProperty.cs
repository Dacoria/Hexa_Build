using System.Collections.Generic;

public class TreesHexStateProperty : IHexStateProperty, IRscGrowthInState, IRscGainsInState
{
    public HexStateType Type => HexStateType.Trees;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile=> HexObjectOnTileType.Tree;
    public string ButtonImageNameToGetInState => "Tree";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5);
    public List<RscGrowthLevel> RscGrowthLevels => RscGrow.CreateList(1, 3, 7, 10);

    public ResourceCostGains RscCostGainsInStatePerTurn =>
        new ResourceCostGains
        {
            Costs = Utils.Rsc(),
            Gains = Utils.Rsc(RscType.Wood, 2)[0],
        };
    public ResourceCostGains RscCostGainsInStatePerAction =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Wood, 2)[0],
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";
    public RscType RscType => RscType.Wood;
    public int RscAvailableInit => 0;

    public HexStateType StateToIfNoMoreRsc => HexStateType.Soil;

    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };

}