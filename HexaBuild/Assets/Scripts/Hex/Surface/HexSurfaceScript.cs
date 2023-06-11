using UnityEngine;

public partial class HexSurfaceScript : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    public void HexSurfaceTypeChanged(HexSurfaceType to)
    {
        var mainGo = Utils.GetMainGo(hex);
        if (mainGo == null || mainGo.transform.childCount == 0)
        {
            return;
        }

        var getGoSurfaceBase = mainGo.transform.GetChild(0);

        if (Load.MaterialTileMap.TryGetValue(to.ToString(), out Material result))
        {
            var meshRenderer = getGoSurfaceBase.GetComponent<MeshRenderer>();
            meshRenderer.material = result;
        }
    }
}
