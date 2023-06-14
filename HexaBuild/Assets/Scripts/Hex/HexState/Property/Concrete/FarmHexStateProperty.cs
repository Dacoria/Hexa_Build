using System.Collections.Generic;

public class FarmHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Farm;
    public HexSurfaceType? Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType? ObjectOnTile => HexObjectOnTileType.Grain;
    public string ButtonImageNameToGetInState => "Grain";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy,5, RscType.Wood, 5);
    public List<HexStateType> AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
    public bool ConditionsForfilledToEnterState(Hex hex) => true;
}