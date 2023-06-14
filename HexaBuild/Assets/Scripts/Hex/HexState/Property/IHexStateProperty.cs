using System.Collections.Generic;
using System.Linq;

public interface IHexStateProperty
{
    public HexStateType Type { get; }
    public HexSurfaceType? Surface { get; }
    public HexObjectOnTileType? ObjectOnTile { get; }
    public string ButtonImageNameToGetInState { get; }
    public List<ResourceAmount> RscCostsToGetInState { get; }
    public List<HexStateType> AllowedNextStateTypes { get; }

    public bool ConditionsForfilledToEnterState(Hex hex);

    public bool StateAllowed(Hex hex, bool checkResources)
    {
        if(checkResources && !ResourceHandler.instance.HasResourcesForChange(RscCostsToGetInState))
        {            
            return false;            
        }
        if(!hex.HexStateType.GetProperties().AllowedNextStateTypes.Any(x => x == Type))
        {
            return false;
        }
        return ConditionsForfilledToEnterState(hex);
    }
}