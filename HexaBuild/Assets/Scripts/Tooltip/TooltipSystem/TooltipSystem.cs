using System;
using System.Collections;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem instance;
    [ComponentInject][HideInInspector] public Tooltip Tooltip;

    [ComponentInject] private CanvasGroup canvasGroup;

    private float waitTimeToShow = 0.5f;
    private float fadeInTime = 0.5f;
    private float fadeOutTime = 0.35f;

    public void Awake()
    {
        instance = this;
        this.ComponentInject();
    }

    void Start()
    {
        Tooltip.gameObject.SetActive(true);
        canvasGroup.alpha = 0; // start invisible
    }    

    private DateTime showTimeTooltip;

    public void Show(string content = "", string header = "", bool waitBeforeShowing = true, GameObject activeTooltipGo = null)
    {
        ActiveTooltipGo = activeTooltipGo;
        instance.Tooltip.SetText(content, header);
        showTimeTooltip = DateTime.Now;

        if (waitBeforeShowing)
        {
            instance.StartCoroutine(instance.ShowAfterXSeconds());
        }
        else
        {
            MonoHelper.instance.FadeIn(canvasGroup, fadeInTime);
        }
    }

    private GameObject ActiveTooltipGo;

    public bool UpdateText(GameObject activeTooltipGo, string content, string header = "")
    {
        // voorkomt dat 2 updates tegelijkertijd bezig zijn (wat kan via een event + rayhit)
        if(activeTooltipGo == ActiveTooltipGo)
        {
            instance.Tooltip.SetText(content, header);
            return true;
        }
        return false;
    }

    public IEnumerator ShowAfterXSeconds()
    {
        yield return Wait4Seconds.Get(waitTimeToShow);
        MonoHelper.instance.FadeIn(canvasGroup, fadeInTime);
    }

    public void Hide(bool ignoreWaitBuffer = false)
    {
        // stel je klikt van 1 tooltip op een persoon naar de volgende --> dan moet de tooltip blijven (uitzondering: hover)

        if (instance != null && (ignoreWaitBuffer || showTimeTooltip.EnoughTimeForNewEvent()))
        {
            
            MonoHelper.instance.FadeOut(canvasGroup, fadeOutTime);
        }
    }
}