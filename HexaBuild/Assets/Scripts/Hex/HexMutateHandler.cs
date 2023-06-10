using System.Linq;
using UnityEngine;

public class HexMutateHandler : MonoBehaviour
{
    public static HexMutateHandler instance;

    private void Awake()
    {
        instance = this;
    }

    public void CreateHexSurface(Hex hex, HexSurfaceType type)
    {
        if (!CanCreateHexSurface(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.ChangeHexSurfaceType(type);
    }

    public bool CanCreateHexSurface(Hex hex, HexSurfaceType newSurfaceType)
    {
        return hex.AllowedHexSurfaceTypes().Any(x => x == newSurfaceType) &&
            ResourceHandler.instance.HasResourcesForChange(newSurfaceType.Cost());
    }

    public void DiscoverHex(Hex hex, ScoutType type)
    {
        if (!CanDiscoverHex(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.DiscoverHex();
    }

    public bool CanDiscoverHex(Hex hex, ScoutType type)
    {
        return hex.CanBeDiscovered() &&
            ResourceHandler.instance.HasResourcesForChange(type.Cost());
    }

    public void BuildOnHex(Hex hex, BuildingType type)
    {
        if (!CanBuildOnHex(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        Debug.Log("BUILD BUILDING: " + type);
    }

    public bool CanBuildOnHex(Hex hex, BuildingType type)
    {
        return hex.CanBuildOn() &&
            ResourceHandler.instance.HasResourcesForChange(type.Cost());
    }

    public void UseSoilOnHex(Hex hex, SoilType type)
    {
        if (!CanUseSoilOnHex(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        Debug.Log("USE SOIL: " + type);
    }

    public bool CanUseSoilOnHex(Hex hex, SoilType type)
    {
        return hex.CanUseSoilOn() &&
            ResourceHandler.instance.HasResourcesForChange(type.Cost());
    }
}