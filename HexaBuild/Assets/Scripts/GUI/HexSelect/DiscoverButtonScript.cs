using UnityEngine.UI;

public class DiscoverButtonScript : BaseEventCallback
{
    public Image Image;
    private Hex hex;
    [ComponentInject] private Button button;
    [ComponentInject] private Image outsideOfButton;

    public void SetDiscoverButton(Hex relatedHex)
    {
        hex = relatedHex;
        Image.sprite = Rsc.SpriteMap.Get("Discover");

        var allowed = HexMutateHandler.instance.CanDiscoverHex(relatedHex);
        button.interactable = allowed; // false maakt het ook direct doorzichtig voor de kleur erachter
        outsideOfButton.color = allowed ? Colorr.Yellow : Colorr.Red;
    }

    public void Click()
    {
        HexButtonsHandler.instance.RemoveAllButtons();
        HexMutateHandler.instance.DiscoverHex(hex);
    }
}