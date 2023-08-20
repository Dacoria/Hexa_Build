using UnityEngine;

public class HexExpandButtonScript : BaseEventCallback, IHexButtonScript
{
    private Hex hex;
    private DirectionType newHexDir;
    [ComponentInject] private UiHexButtonScript uiHexButton;

    public GameObject GetGo() => gameObject;

    public void SetHexValue(Hex relatedHex, DirectionType direction)
    {
        hex = relatedHex;
        newHexDir = direction;

        uiHexButton.SetSprite(Load.SpriteMap.Get(direction.ToString()), isTransparentImage: true);
        uiHexButton.SetAllowed(true);
        uiHexButton.SetButtonAction(() => Click());
    }

    public void Click()
    {
        ShowHexButtonsHandler.instance.RemoveAllButtons();

        ResourceHandler.instance.RemoveResources(HexExpansion.ExpansionCost());
        var newCoordinate = hex.HexCoordinates.GetNewHexCoorFromDirection(newHexDir);
        HexGrid.instance.CreateNewHex(newCoordinate);
    }

    public TooltipTexts GetTooltipTexts() =>
        new TooltipTexts(header: "Direction", content: "New hex in direction: " + newHexDir.ToString());
}