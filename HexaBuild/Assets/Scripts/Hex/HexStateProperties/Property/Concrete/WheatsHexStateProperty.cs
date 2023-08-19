using System.Collections.Generic;

public class WheatsHexStateProperty : IHexStateProperty, IRscGrowthInState, IRscGainsInState
{
    public HexStateType Type => HexStateType.Wheats;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Wheat;
    public string ButtonImageNameToGetInState => "Wheat";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 2);
    public List<RscGrowthLevel> RscGrowthLevels => RscGrow.CreateList(1, 3, 8);

    public ResourceCostGains RscCostGainsInStatePerTurn =>
        new ResourceCostGains
        {
            Costs = Utils.Rsc(),
            Gains = Utils.Rsc(RscType.Food, 2)[0],
        };
    public ResourceCostGains RscCostGainsInStatePerAction =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Food, 2)[0],
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";
    public RscType RscType => RscType.Food;
    public int RscAvailableInit => 0;

    public HexStateType StateToIfNoMoreRsc => HexStateType.Soil;
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}