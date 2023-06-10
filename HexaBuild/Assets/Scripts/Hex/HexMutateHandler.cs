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

    public bool CanCreateHexSurface(Hex hex, HexSurfaceType? newSurfaceType = null)
    {
        return hex.AllowedHexSurfaceTypes().Any(x => x == newSurfaceType) &&
            (newSurfaceType.HasValue ? ResourceHandler.instance.HasResourcesForChange(newSurfaceType.Value.Cost()) : true);
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

    public bool CanDiscoverHex(Hex hex, ScoutType? type = null)
    {
        return hex.HexSurfaceType.IsDiscoverable() &&
            (type.HasValue ? ResourceHandler.instance.HasResourcesForChange(type.Value.Cost()) : true);
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

    public bool CanBuildOnHex(Hex hex, BuildingType? type = null)
    {
        return hex.HexSurfaceType.IsBuildGround() &&
            hex.HexObjectOnTileType == HexObjectOnTileType.None &&
            (type.HasValue ? ResourceHandler.instance.HasResourcesForChange(type.Value.Cost()) : true);
    }

    public void UseSoilOnHex(Hex hex, SoilType type)
    {
        if (!CanPlantOnSoilHex(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.PlantCost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.ChangeHexObjOnTile(type.GetObjType());
    }

    public bool CanPlantOnSoilHex(Hex hex, SoilType? type = null)
    {
        return hex.HexSurfaceType.IsSoilGround() &&
            hex.HexObjectOnTileType == HexObjectOnTileType.None &&
            (type.HasValue ? ResourceHandler.instance.HasResourcesForChange(type.Value.PlantCost()) : true);
    }

    public void HarvestSoilObjOnHex(Hex hex)
    {
        var type = hex.HexObjectOnTileType.GetSoilType();
        if (!CanHarvestSoilObjOnHex(hex))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.HarvestCost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        type.HarvestGain().ForEach(x => ResourceHandler.instance.AddResource(x.Type, x.Amount));
    }

    public bool CanHarvestSoilObjOnHex(Hex hex, bool checkResources = true)
    {
        return hex.HexSurfaceType.IsSoilGround() &&
            hex.HexObjectOnTileType != HexObjectOnTileType.None &&
            (checkResources ? ResourceHandler.instance.HasResourcesForChange(hex.HexObjectOnTileType.GetSoilType().HarvestCost()) : true);
    }
}