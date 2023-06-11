using System.Linq;
using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{    
    public void CreateHexSurface(Hex hex, HexSurfaceType type)
    {
        if (!CanChangeHexSurface(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.ChangeHexSurfaceType(type);
    }

    public bool CanChangeHexSurface(Hex hex, HexSurfaceType? newSurfaceType = null)
    {
        return hex.AllowedHexSurfaceTypes().Any() &&
            (newSurfaceType.HasValue ? ResourceHandler.instance.HasResourcesForChange(newSurfaceType.Value.Cost()) : true);
    }
}