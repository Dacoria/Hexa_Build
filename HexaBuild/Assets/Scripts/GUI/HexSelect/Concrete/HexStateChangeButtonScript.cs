using UnityEngine;

public class HexStateChangeButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private HexStateType newState;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    public void SetHexValue(Hex relatedHex, HexStateType typeToEnter)
    {
        hex = relatedHex;
        newState = typeToEnter;

        uiHexButton.SetSprite(Load.SpriteMap.Get(typeToEnter.Props().ButtonImageNameToGetInState), isTransparentImage: true);
        uiHexButton.SetAllowed(typeToEnter.Props().StateAllowed(relatedHex, checkResources: true));
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();
        hex.ChangeState(newState);
    }    

    public TooltipTexts GetTooltipTexts() => HexButtonTooltipTexts.Generate(newState, HexSelectCategoryType.StateChange);
}