using System.Collections.Generic;

public class WheatsHexStateProperty : IHexStateProperty // , IRscGrowthInState
{
    public HexStateType Type => HexStateType.Wheats;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Grain;
    public string ButtonImageNameToGetInState => "Grain";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Wood, 2);
    //public List<RscGrowthLevel> RscPerGrowthLevel => RscGrow.CreateList(1, 10, 40, 100);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Farm };
}