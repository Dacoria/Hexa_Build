using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHexSurfaceButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private HexSurfaceType hexSurfaceType;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    public void SetHexValue<T>(T type, Hex relatedHex) where T : Enum
    {
        hexSurfaceType = (HexSurfaceType)Enum.Parse(typeof(HexSurfaceType), type.ToString());
        hex = relatedHex;

        uiHexButton.SetSprite(Load.SpriteMap.Get(hexSurfaceType.ToString()), isTransparentImage: false);
        uiHexButton.SetAllowed(HexActionHandler.instance.CanChangeHexSurface(relatedHex, hexSurfaceType));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        HexActionHandler.instance.CreateHexSurface(hex, hexSurfaceType);
    }

    public TooltipTexts GetTooltipTexts()
    {
        return HexButtonTooltipTexts.Generate(
            "Create " + hexSurfaceType.Name(),
            hexSurfaceType.Cost());
    }
}