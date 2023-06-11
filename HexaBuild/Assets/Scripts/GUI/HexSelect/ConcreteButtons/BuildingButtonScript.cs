using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BuildingButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private BuildingType buildingType;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    void IHexButtonScript.SetHexValue<T>(T type, Hex relatedHex)
    {
        buildingType = (BuildingType)Enum.Parse(typeof(BuildingType), type.ToString());
        hex = relatedHex;

        uiHexButton.SetSprite(Load.SpriteMap.Get(buildingType.ToString()), isTransparentImage: true);
        uiHexButton.SetAllowed(HexActionHandler.instance.CanBuildOnHex(relatedHex, buildingType));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        HexActionHandler.instance.BuildOnHex(hex, buildingType);
    }

    public TooltipTexts GetTooltipTexts()
    {
        return HexButtonTooltipTexts.Generate(buildingType.ToString(), buildingType.Cost());
    }
}