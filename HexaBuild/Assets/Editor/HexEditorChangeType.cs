
using System;
using System.Linq;
using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Hex)), CanEditMultipleObjects]
public class HexEditorChangeType : Editor
{
    private Hex previousSelectedHex;
    private HexStateType previousHexStateType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var hexes = targets.Select(x => (Hex)x).ToList();

        //return;
        if (!EditorGUILayoutToggle.UseEditorGuiScripts)
        {
            return;
        }
        if (Application.isPlaying)
        {
            return;
        }

        var firstHex = (Hex)target;        
        if (previousSelectedHex == firstHex && previousHexStateType != firstHex.HexStateType)
        {
            var props = firstHex.HexStateType.Props();
            hexes.ForEach(hex => HexEditorUtil.HexSurfaceTypeChanged(hex, props.Surface));
            hexes.ForEach(hex => HexEditorUtil.HexObjectOnTileTypeChanged(hex, props.ObjectOnTile));
        }        

        previousSelectedHex = firstHex;
        previousHexStateType = firstHex.HexStateType;
    }
}

