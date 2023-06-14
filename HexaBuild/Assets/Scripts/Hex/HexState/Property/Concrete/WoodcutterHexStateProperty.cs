using System.Collections.Generic;

public class WoodcutterHexStateProperty : IHexStateProperty, IRscGainsInState
{
    public HexStateType Type => HexStateType.Woodcutter;
    public HexSurfaceType Surface => HexSurfaceExt.Soil();
    public HexObjectOnTileType ObjectOnTile => HexObjectOnTileType.Woodcutter;
    public string ButtonImageNameToGetInState => "Woodcutter";
    public List<ResourceAmount> RscCostsToGetInState => Utils.Rsc(RscType.Energy, 5, RscType.Mana, 2);
    public List<ResourceAmount> RscGainsInState => Utils.Rsc(RscType.Energy, 2, RscType.Wood, 1);
    List<HexStateType> IHexStateProperty.AllowedNextStateTypes => new List<HexStateType> { HexStateType.Soil };
}