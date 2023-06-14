using System.Collections.Generic;

public class WheatsHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Wheats;
    public HexSurfaceType? Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType? ObjectOnTile => HexObjectOnTileType.Grain;
    public string ButtonImageNameToGetInState => "Grain";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 2);
    public List<ResourceAmount> RscGainsInState => Utils.Rsc(RscType.Mana, 2);
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Barren };
    public bool ConditionsForfilledToEnterState(Hex hex) => true;
}