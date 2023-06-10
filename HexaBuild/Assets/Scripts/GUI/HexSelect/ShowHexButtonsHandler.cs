using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShowHexButtonsHandler : BaseEventCallback
{
    [HideInInspector]
    public static ShowHexButtonsHandler instance;

    public GameObject HexButtonPrefab;

    private List<IHexButtonScript> activeButtons = new List<IHexButtonScript>();

    [ComponentInject] private CanvasGroup canvasGroup;

    protected new void Awake()
    {
        base.Awake();
        instance = this;
        canvasGroup.alpha = 0; // invisible
    }

    public void LoadSurfaceButtons(Hex relatedHex) =>
        LoadButtons<HexSurfaceType, HexSurfaceButtonScript>(relatedHex, relatedHex.AllowedHexSurfaceTypes());
    public void LoadScoutButtons(Hex relatedHex) =>
        LoadButtons<ScoutType, ScoutButtonScript>(relatedHex);
    public void LoadPlantSoilButtons(Hex relatedHex) =>
        LoadButtons<SoilType, SoilButtonScript>(relatedHex);
    public void LoadBuildButtons(Hex relatedHex) =>
        LoadButtons<BuildingType, BuildingButtonScript>(relatedHex);
    public void LoadHarvestSoilButtons(Hex relatedHex) =>
        LoadButtons<SoilType, HarvestSoilButtonScript>(relatedHex, 
            new List<SoilType> { relatedHex.HexObjectOnTileType.GetSoilType()});

    private void LoadButtons<T,S>(Hex selectedHex, List<T> values = null) 
        where T : Enum 
        where S : MonoBehaviour, IHexButtonScript
    {
        ResetActiveButtons();

        IEnumerable enumValues = values != null ? values : Enum.GetValues(typeof(T));
        foreach (T surfaceType in enumValues)
        {
            var buttonGo = Instantiate(HexButtonPrefab, transform);
            buttonGo.AddComponent<S>();

            var buttonScript = buttonGo.GetComponent<IHexButtonScript>();
            buttonScript.SetHexValue(surfaceType, selectedHex);
            activeButtons.Add(buttonScript);
        }

        MonoHelper.instance.FadeIn(canvasGroup, 1f, stopOtherCR: true);
    }

    public void RemoveAllButtons()
    {
        ResetActiveButtons();
        canvasGroup.alpha = 0;
    }

    private void ResetActiveButtons()
    {
        activeButtons.ForEach(button => Destroy(button.GetGo()));
        activeButtons.Clear();
    }
}
