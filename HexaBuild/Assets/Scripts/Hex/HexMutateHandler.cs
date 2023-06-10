using System.Linq;
using UnityEngine;

public class HexMutateHandler : MonoBehaviour
{
    public static HexMutateHandler instance;

    private void Awake()
    {
        instance = this;
    }

    public void BuildHexSurface(Hex hex, HexSurfaceType newSurfaceType)
    {
        if (!CanBuildHexSurface(hex, newSurfaceType))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        newSurfaceType.BuildCost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.ChangeHexSurfaceType(newSurfaceType);
    }

    public bool CanBuildHexSurface(Hex hex, HexSurfaceType newSurfaceType)
    {
        return hex.AllowedHexSurfaceTypes().Any(x => x == newSurfaceType) &&
            ResourceHandler.instance.HasResourcesForHexSurfaceChange(newSurfaceType);
    }

    public void DiscoverHex(Hex hex)
    {
        if (!ResourceHandler.instance.HasResourcesToDiscoverHex())
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        ResourceHandler.instance.RemoveResourcesToDiscoverHex();
        hex.DiscoverHex();
        // TODO MONSTER?
    }

    public bool CanDiscoverHex(Hex hex)
    {
        return hex.CanBeDiscovered() &&
            ResourceHandler.instance.HasResourcesToDiscoverHex();
    }
}