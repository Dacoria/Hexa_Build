using System.Collections.Generic;

public class FarmHexStateProperty : IHexStateProperty
{
    public HexStateType Type => HexStateType.Farm;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Farm;
    public string ButtonImageNameToGetInState => "Harvest_Grain";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy,5, RscType.Wood, 5);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}