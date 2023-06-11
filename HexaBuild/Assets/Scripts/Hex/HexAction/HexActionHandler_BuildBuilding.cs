using System.Linq;
using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{
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
}