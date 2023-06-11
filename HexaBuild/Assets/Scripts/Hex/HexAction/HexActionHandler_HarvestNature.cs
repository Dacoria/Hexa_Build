using System.Linq;
using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{    
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