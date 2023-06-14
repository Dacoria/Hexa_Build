using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class HexButtonTooltipCanvas : TooltipCanvas
{   
    [ComponentInject] private HexStateChangeButtonScript hexButtonScript;

    private void Awake()
    {
        this.ComponentInject();
    }

    protected override void ShowTooltip()
    {
        var tt = hexButtonScript.GetTooltipTexts();
        TooltipSystem.instance.Show(content: tt.Content, header: tt.Header, waitBeforeShowing: false);
    }
}
