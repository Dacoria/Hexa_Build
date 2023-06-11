using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HarvestSoilButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private SoilType harvestType;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    void IHexButtonScript.SetHexValue<T>(T type, Hex relatedHex)
    {
        harvestType = (SoilType)Enum.Parse(typeof(SoilType), type.ToString());
        hex = relatedHex;
                
        uiHexButton.SetSprite(Load.SpriteMap.Get("Take"), isTransparentImage: true);
        uiHexButton.SetAllowed(HexMutateHandler.instance.CanHarvestSoilObjOnHex(relatedHex));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        HexMutateHandler.instance.HarvestSoilObjOnHex(hex);
    }

    public TooltipTexts GetTooltipTexts()
    {
        return HexButtonTooltipTexts.Generate(
            "Harvest " + harvestType.ToString(),
            harvestType.HarvestCost(),
            harvestType.HarvestGain());
    }
}