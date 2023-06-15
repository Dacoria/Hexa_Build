using System.Collections.Generic;

public class FarmHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Farm;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Farm;
    public string ButtonImageNameToGetInState => "Harvest_Grain";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy,5, RscType.Wood, 5);
    public ResourceCostGains RscCostGainsInState =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Mana, 2),
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}