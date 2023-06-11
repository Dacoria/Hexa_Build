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

    public void LoadChangeHexSurfaceButtons(Hex relatedHex) =>
        LoadButtons<HexSurfaceType, ChangeHexSurfaceButtonScript>(relatedHex, relatedHex.AllowedHexSurfaceTypes());
    public void LoadScoutButtons(Hex relatedHex) =>
        LoadButtons<ScoutType, ScoutButtonScript>(relatedHex);
    public void LoadPlantSoilButtons(Hex relatedHex) =>
        LoadButtons<SoilType, PlantSoilButtonScript>(relatedHex);
    public void LoadBuildButtons(Hex relatedHex) =>
        LoadButtons<BuildingType, BuildingButtonScript>(relatedHex);
    public void LoadHarvestSoilButtons(Hex relatedHex) =>
        LoadButtons<SoilType, HarvestSoilButtonScript>(relatedHex, 
            new List<SoilType> { relatedHex.HexObjectOnTileType.GetSoilType()});

    private void LoadButtons<EnumType,HexButtonScriptType>(Hex selectedHex, List<EnumType> values = null) 
        where EnumType : Enum 
        where HexButtonScriptType : MonoBehaviour, IHexButtonScript
    {
        ResetActiveButtons();

        IEnumerable enumValues = values != null ? values : Enum.GetValues(typeof(EnumType));
        foreach (EnumType surfaceType in enumValues)
        {
            var buttonGo = Instantiate(HexButtonPrefab, transform);
            buttonGo.AddComponent<HexButtonScriptType>();
            buttonGo.transform.GetChild(0).GetChild(0).gameObject.AddComponent<HexButtonTooltipCanvas>();

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