using System.Collections.Generic;

public class WoodcutterHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Woodcutter;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Woodcutter;
    public string ButtonImageNameToGetInState => "Woodcutter";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Mana, 2);
    public ResourceCostGains RscCostGainsInState =>
        new ResourceCostGains
        {
            Gains = Utils.Rsc(RscType.Wood, 2),
            Costs = Utils.Rsc(RscType.Energy, 5),
        };
    public string ButtonImageNameToGetRsc => "Take";
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}