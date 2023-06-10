using UnityEngine;

public class HexObjectOnTileScript : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    public void HexObjectOnTileTypeChanged(HexObjectOnTileType to)
    {
        var structureGo = hex.GetStructuresGo();
        Utils.GetChildrenGos(structureGo).ForEach(x => Destroy(x));
        if (to != HexObjectOnTileType.None)
        {
            if (Load.GoEnemiesOrObjMap.TryGetValue(to.ToString(), out GameObject result))
            {
                var go = Instantiate(result, structureGo.transform);
                go.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }

    }
}