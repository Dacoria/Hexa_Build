using System.Collections.Generic;
using System.Linq;

public interface IHexStateProperty
{
    public HexStateType Type { get; }
    public HexSurfaceType Surface { get; }
    public HexObjectOnTileType ObjectOnTile { get; }
    public string ButtonImageNameToGetInState { get; }
    public List<ResourceAmount> RscCostsToGetInState { get; }
    protected List<HexStateType> AllowedNextStateTypes { get; }
    public List<HexStateType> PossibleNextStateTypes(Hex hex, bool checkResources = false) =>
        AllowedNextStateTypes.Where(x => x.Props().StateAllowed(hex, checkResources)).ToList();

    protected bool ConditionsForfilledToEnterState(Hex hex) => true; // can overwrite
    protected bool ConditionsForfilledToLeaveState(Hex hex) => true; // can overwrite

    public bool StateAllowed(Hex hex, bool checkResources)
    {
        if(checkResources && !ResourceHandler.instance.HasResourcesForUse(RscCostsToGetInState))
        {            
            return false;            
        }
        if(!hex.HexStateType.Props().AllowedNextStateTypes.Any(x => x == Type))
        {
            return false;
        }
        if(!ConditionsForfilledToEnterState(hex))
        {
            return false;
        }
        if (!hex.HexStateType.Props().ConditionsForfilledToLeaveState(hex))
        {
            return false;
        }

        return true;
    }
}