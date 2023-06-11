using System.Linq;
using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{    
    public void ScoutHex(Hex hex, ScoutType type)
    {
        if (!CanScoutHex(hex, type))
        {
            throw new System.Exception("Zou je eerder verwachten op te vangen");
        }

        type.Cost().ForEach(x => ResourceHandler.instance.RemoveResource(x.Type, x.Amount));
        hex.ScoutHex();
    }

    public bool CanScoutHex(Hex hex, ScoutType? type = null)
    {
        return hex.HexSurfaceType.IsScoutable() &&
            HexGrid.instance.GetNeighboursFor(hex.HexCoordinates, range: 1).Any() &&
            (type.HasValue ? ResourceHandler.instance.HasResourcesForChange(type.Value.Cost()) : true);
    }
}