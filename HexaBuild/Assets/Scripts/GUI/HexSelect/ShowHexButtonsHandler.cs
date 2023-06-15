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

    private void LoadButtons<T, ButtonClass>(List<T> options, Action<T, ButtonClass> setAction)
        where T : Enum
        where ButtonClass : MonoBehaviour, IHexButtonScript
    {
        ResetActiveButtons();

        foreach (var option in options)
        {
            var buttonGo = Instantiate(HexButtonPrefab, transform);
            buttonGo.AddComponent<ButtonClass>();
            buttonGo.transform.GetChild(0).GetChild(0).gameObject.AddComponent<HexButtonTooltipCanvas>();

            var buttonScript = buttonGo.GetComponent<ButtonClass>();
            setAction.Invoke(option, buttonScript);

            activeButtons.Add(buttonScript);
        }

        MonoHelper.instance.FadeIn(canvasGroup, 1f, stopOtherCR: true);
    }

    public void LoadHexSelectButtons(Hex hexSelected)
    {
        var availableValues = Enum.GetValues(typeof(HexSelectCategoryType)).List<HexSelectCategoryType>()
            .Where(x => x.IsCategoryAvailable(hexSelected.HexStateType)).ToList();

        LoadButtons(availableValues,
            setAction: (HexSelectCategoryType category, HexSelectCategoryButtonScript buttonScript) =>
               buttonScript.SetHexValue(hexSelected, category)
            );
    }

    public void LoadHexStateChangeButtons(Hex hexSelected)
    {
        var nextStates = hexSelected.HexStateType.Props().PossibleNextStateTypes(hexSelected);        

        LoadButtons(nextStates,
            setAction: (HexStateType nextState, HexStateChangeButtonScript buttonScript) =>
               buttonScript.SetHexValue(hexSelected, nextState)
            );
    }

    public void LoadGainRscButtons(Hex hexSelected)
    {
        LoadButtons(Enum.GetValues(typeof(HexGainRscOptionType)).List<HexGainRscOptionType>(),
            setAction: (HexGainRscOptionType gainOption, HexGainRscButtonScript buttonScript) =>
               buttonScript.SetHexValue(hexSelected, gainOption)
            );
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