using UnityEngine.UI;

public class HexSurfaceButtonScript : BaseEventCallback
{
    public Image Image;
    private Hex hex;
    private HexSurfaceType hexSurfaceType;
    [ComponentInject] private Button button;
    [ComponentInject] private Image outsideOfButton;

    public void SetHexSurface(HexSurfaceType newHexSurfaceType, Hex relatedHex)
    {
        hex = relatedHex;
        hexSurfaceType = newHexSurfaceType;
        Image.sprite = Rsc.SpriteMap.Get(newHexSurfaceType.ToString());
        
        var allowed = HexMutateHandler.instance.CanBuildHexSurface(relatedHex, newHexSurfaceType);
        button.interactable = allowed; // false maakt het ook direct doorzichtig voor de kleur erachter
        outsideOfButton.color = allowed ? Colorr.Yellow : Colorr.Red;
    }

    public void Click()
    {
        HexButtonsHandler.instance.RemoveAllButtons();
        HexMutateHandler.instance.BuildHexSurface(hex, hexSurfaceType);
    }
}