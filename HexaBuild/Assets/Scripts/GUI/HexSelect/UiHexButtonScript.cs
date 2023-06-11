using System;
using UnityEngine;
using UnityEngine.UI;

public class UiHexButtonScript : BaseEventCallback
{
    [ComponentInject] private Button Button;
    [ComponentInject] private Image OutsideOfButton;
    private Image Image;

    private new void Awake()
    {
        base.Awake();
        Image = Button.GetComponent<Image>();
    }

    public GameObject GetGo() => gameObject;

    public void SetAllowed(bool allowed)
    {
        Button.interactable = allowed; // false maakt het ook direct doorzichtig voor de kleur erachter
        OutsideOfButton.color = allowed ? Colorr.Yellow : Colorr.Red;        
    }

    public void SetSprite(Sprite sprite, bool isTransparentImage)
    {
        Image.sprite = sprite;   
        
        var backgroundImage = Button.transform.parent.GetComponent<Image>();

        if (!isTransparentImage)
        {
            // materials --> dan heb je de outline al -> compenseren
            Image.transform.localScale = new Vector3(1f * 1.15f, 1f * 1.15f, 0);

            // anders is het zo wit....zeker bij rood
            backgroundImage.color = backgroundImage.color.SetA(0.85f);
        }
    }

    public void SetButtonAction(Action callBack)
    {
        Button.onClick.AddListener(() => callBack?.Invoke());
    }
}