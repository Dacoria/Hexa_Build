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

    private List<HexStateChangeButtonScript> activeButtons = new List<HexStateChangeButtonScript>();

    [ComponentInject] private CanvasGroup canvasGroup;

    protected new void Awake()
    {
        base.Awake();
        instance = this;
        canvasGroup.alpha = 0; // invisible
    }

    public void LoadHexSelectButtons(Hex hexSelected)
    {
        ResetActiveButtons();
        var nextStates = hexSelected.HexStateType.Props().PossibleNextStateTypes(hexSelected);

        foreach (var nextState in nextStates)
        {
            var buttonGo = Instantiate(HexButtonPrefab, transform);
            buttonGo.AddComponent<HexStateChangeButtonScript>();
            buttonGo.transform.GetChild(0).GetChild(0).gameObject.AddComponent<HexButtonTooltipCanvas>();

            var buttonScript = buttonGo.GetComponent<HexStateChangeButtonScript>();

            buttonScript.SetHexValue(hexSelected, nextState);
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