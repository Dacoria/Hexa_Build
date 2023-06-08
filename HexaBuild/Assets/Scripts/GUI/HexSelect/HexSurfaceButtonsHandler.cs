using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexSurfaceButtonsHandler : BaseEventCallback
{
    [HideInInspector]
    public static HexSurfaceButtonsHandler instance;

    public HexSurfaceButtonScript HexSurfaceButtonPrefab;
    public List<HexSurfaceButtonScript> activeHexSurfaceButtons = new List<HexSurfaceButtonScript> ();

    [ComponentInject] private CanvasGroup canvasGroup;

    protected new void Awake()
    {
        base.Awake();
        instance = this;
        canvasGroup.alpha = 0; // invisible
    }   

    public void LoadSurfaceButtons(Hex selectedHex)
    {
        ResetActiveHexSurfaceButtons();

        foreach (var surfaceType in selectedHex.AllowedHexSurfaceTypes())
        {
            var hexSurfaceButtonGo = Instantiate(HexSurfaceButtonPrefab, transform);
            hexSurfaceButtonGo.SetHexSurface(surfaceType, selectedHex);
            activeHexSurfaceButtons.Add(hexSurfaceButtonGo);
        }

        MonoHelper.instance.FadeIn(canvasGroup, 1f);
    }

    public void RemoveSurfaceButtons()
    {
        ResetActiveHexSurfaceButtons();
        canvasGroup.alpha = 0;
    }

    private void ResetActiveHexSurfaceButtons()
    {
        activeHexSurfaceButtons.ForEach(hexSurfaceButton => Destroy(hexSurfaceButton.gameObject));
        activeHexSurfaceButtons.Clear();
    }
}
