using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoutButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private ScoutType scoutType;

    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    void IHexButtonScript.SetHexValue<T>(T type, Hex relatedHex)
    {
        scoutType = (ScoutType)Enum.Parse(typeof(ScoutType), type.ToString());
        hex = relatedHex;

        uiHexButton.SetSprite(Load.SpriteMap.Get(scoutType.ToString()), isTransparentImage: true);
        uiHexButton.SetAllowed(HexMutateHandler.instance.CanDiscoverHex(relatedHex, scoutType));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        HexMutateHandler.instance.DiscoverHex(hex, scoutType);
    }

    public TooltipTexts GetTooltipTexts()
    {
        return HexButtonTooltipTexts.Generate(
            scoutType.ToString(),
            scoutType.Cost());
    }
}