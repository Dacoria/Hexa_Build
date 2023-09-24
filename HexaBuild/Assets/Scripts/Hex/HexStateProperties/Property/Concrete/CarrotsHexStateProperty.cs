using System.Collections.Generic;

public class CarrotsHexStateProperty : IHexStateProperty, IRscGrowthInState, IRscGainsInState
{
    public HexStateType Type => HexStateType.Carrots;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Carrot;
    public string ButtonImageNameToGetInState => "Carrot";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 2);
    public List<RscGrowthLevel> RscGrowthLevels => RscGrow.CreateList(1, 2, 3, 4);

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