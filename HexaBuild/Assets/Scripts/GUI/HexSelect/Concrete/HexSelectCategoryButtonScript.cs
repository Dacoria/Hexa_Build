using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HexSelectCategoryButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private HexSelectCategoryType hexSelectCategoryType;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    public void SetHexValue(Hex relatedHex, HexSelectCategoryType hexSelectCategoryType)
    {
        hex = relatedHex;
        this.hexSelectCategoryType = hexSelectCategoryType;

        uiHexButton.SetSprite(Load.SpriteMap.Get(hexSelectCategoryType.ToString()), isTransparentImage: true);
        uiHexButton.SetButtonAction(Click);
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        switch (hexSelectCategoryType)
        {
            case HexSelectCategoryType.StateChange:
                ShowHexButtonsHandler.instance.LoadHexStateChangeButtons(hex);
                break;
            case HexSelectCategoryType.GainRsc:
                ShowHexButtonsHandler.instance.LoadGainRscButtons(hex);
                break;
            default:
                throw new Exception("");
        }
    }    

    public TooltipTexts GetTooltipTexts()
    {
        return new TooltipTexts(
            header: hexSelectCategoryType.ToString(),
            content: "Buttons for " + hexSelectCategoryType.ToString()
        );
    }
}