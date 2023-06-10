using System;
using UnityEngine;
using UnityEngine.UI;

public class SoilButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private SoilType soilType;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    void IHexButtonScript.SetHexValue<T>(T type, Hex relatedHex)
    {
        soilType = (SoilType)Enum.Parse(typeof(SoilType), type.ToString());
        hex = relatedHex;

        uiHexButton.SetSprite(Load.SpriteMap.Get(soilType.ToString()), isTransparentImage: true);
        uiHexButton.SetAllowed(HexMutateHandler.instance.CanUseSoilOnHex(relatedHex, soilType));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        HexMutateHandler.instance.UseSoilOnHex(hex, soilType);
    }
}