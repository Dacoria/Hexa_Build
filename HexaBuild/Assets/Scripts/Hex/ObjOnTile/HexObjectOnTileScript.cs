using UnityEngine;

public class HexObjectOnTileScript : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    public void HexObjectOnTileTypeChanged(HexObjectOnTileType to, int hexStateLevel)
    {
        var structureGo = hex.GetStructuresGo();
        Utils.GetChildrenGos(structureGo).ForEach(x => Destroy(x));
        if (to != HexObjectOnTileType.None)
        {
            if (Load.GoMap.TryGetValue(to.ToString() + "_" + hexStateLevel, out GameObject result1))
            {
                var go = Instantiate(result1, structureGo.transform);
                go.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else if (Load.GoMap.TryGetValue(to.ToString(), out GameObject result2))
            {
                var go = Instantiate(result2, structureGo.transform);
                go.transform.rotation = new Quaternion(0, 180, 0, 0);
            }

        }

    }
}