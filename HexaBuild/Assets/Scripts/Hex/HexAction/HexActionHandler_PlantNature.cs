using System.Linq;
using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{
    public void PlantOnSoilHex(Hex hex, SoilType type)
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
}