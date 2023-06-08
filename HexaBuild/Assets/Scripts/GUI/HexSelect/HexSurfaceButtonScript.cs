using UnityEngine.UI;

public class HexSurfaceButtonScript : BaseEventCallback
{
    public Image Image;
    private Hex hex;
    private HexSurfaceType hexSurfaceType;

    public void SetHexSurface(HexSurfaceType newHexSurfaceType, Hex relatedHex)
    {
        hex = relatedHex;
        hexSurfaceType = newHexSurfaceType;
        Image.sprite = Rsc.SpriteMap.Get(newHexSurfaceType.ToString());
    }

    public void Click()
    {
        HexSurfaceButtonsHandler.instance.RemoveSurfaceButtons();
        hex.ChangeHexSurfaceType(hexSurfaceType);
    }
}