using UnityEngine;

public class HexGainRscButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    public void SetHexValue(Hex relatedHex, HexGainRscOptionType type)
    {
        hex = relatedHex;
        var props = relatedHex.HexStateType.Props() as IRscGainsInState;

        uiHexButton.SetSprite(Load.SpriteMap.Get(type.ToString()), isTransparentImage: true);
        uiHexButton.SetAllowed(ResourceHandler.instance.HasResourcesForUse(props.RscCostGainsInStatePerAction.Costs));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        var gainBehaviour = hex.GetComponent<RscGainBehaviour>();

        gainBehaviour.ManualGainRsc();        
    }

    public TooltipTexts GetTooltipTexts() => HexButtonTooltipTexts.Generate(hex.HexStateType, HexSelectCategoryType.GainRsc);
}