﻿
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

public static class HexEditorUtil
{
    public static void HexSurfaceTypeChanged(Hex hex, HexSurfaceType to)
    {
        var mainGo = hex.GetMainGo();
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

        EditorUtility.SetDirty(hex);
        EditorSceneManager.MarkSceneDirty(hex.gameObject.scene);
    }
 
    public static void HexObjectOnTileTypeChanged(Hex hex, HexObjectOnTileType to)
    {
        var structureGo = hex.GetStructuresGo();
        DestroyChildrenOfGo(structureGo);
        if(to != HexObjectOnTileType.None)
        {
            if (Load.GoMap.TryGetValue(to.ToString(), out GameObject result))
            {
                var go = PrefabUtility.InstantiatePrefab(result, structureGo.transform) as GameObject;
                go.transform.rotation = new Quaternion(0, 180, 0, 0);                
            }
        }

        EditorUtility.SetDirty(hex);
        EditorSceneManager.MarkSceneDirty(hex.gameObject.scene);
    }

    public static void DestroyChildrenOfGo(GameObject structuresGo)
    {
        for (int i = structuresGo.transform.childCount - 1; i >= 0; i--)
        {
            var child = structuresGo.transform.GetChild(i);
            Object.DestroyImmediate(child.gameObject);
        }
    }      

    public static Hex GetHexRightUpperCorner()
    {
        var currentHexes = GameObject.FindObjectsOfType<Hex>();
        var hexRightUpperCornerCoordinate = currentHexes.Select(x => x.transform.position.ConvertPositionToCoordinates())
            .OrderByDescending(z => z.z)
            .ThenByDescending(x => x.x)
            .First();
        var hexRightUpperCorner = currentHexes.First(x => x.transform.position.ConvertPositionToCoordinates() == hexRightUpperCornerCoordinate);

        return hexRightUpperCorner;
    }

    public static void ResetHexToDefault(Hex hex)
    {
        hex.HexSurfaceType = HexSurfaceType.Simple_Plain;
        HexSurfaceTypeChanged(hex, hex.HexSurfaceType);

        hex.HexObjectOnTileType = HexObjectOnTileType.None;

        EditorUtility.SetDirty(hex);
        EditorSceneManager.MarkSceneDirty(hex.gameObject.scene);
    }
}

