using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexButtonsHandler : BaseEventCallback
{
    [HideInInspector]
    public static HexButtonsHandler instance;

    public HexSurfaceButtonScript HexSurfaceButtonPrefab;
    public List<HexSurfaceButtonScript> activeHexSurfaceButtons = new List<HexSurfaceButtonScript>();

    public DiscoverButtonScript DiscoverButtonPrefab;
    public List<DiscoverButtonScript> activeDiscoverSurfaceButtons = new List<DiscoverButtonScript>();

    [ComponentInject] private CanvasGroup canvasGroup;

    protected new void Awake()
    {
        base.Awake();
        instance = this;
        canvasGroup.alpha = 0; // invisible
    }   

    public void LoadSurfaceButtons(Hex selectedHex)
    {
        ResetActiveButtons();

        foreach (var surfaceType in selectedHex.AllowedHexSurfaceTypes())
        {
            var hexSurfaceButtonGo = Instantiate(HexSurfaceButtonPrefab, transform);
            hexSurfaceButtonGo.SetHexSurface(surfaceType, selectedHex);
            activeHexSurfaceButtons.Add(hexSurfaceButtonGo);
        }

        MonoHelper.instance.FadeIn(canvasGroup, 1f);
    }

    public void LoadDiscoverButtons(Hex selectedHex)
    {
        ResetActiveButtons();

        // meer acties voor discover? for each hier
        var discoverButtonGo = Instantiate(DiscoverButtonPrefab, transform);
        discoverButtonGo.SetDiscoverButton(selectedHex);
        activeDiscoverSurfaceButtons.Add(discoverButtonGo);

        MonoHelper.instance.FadeIn(canvasGroup, 1f);
    }

    public void RemoveAllButtons()
    {
        ResetActiveButtons();
        canvasGroup.alpha = 0;
    }

    private void ResetActiveButtons()
    {
        activeHexSurfaceButtons.ForEach(hexSurfaceButton => Destroy(hexSurfaceButton.gameObject));
        activeHexSurfaceButtons.Clear();

        activeDiscoverSurfaceButtons.ForEach(button => Destroy(button.gameObject));
        activeDiscoverSurfaceButtons.Clear();
    }
}
