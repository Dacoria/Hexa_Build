using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipUIHandler : MonoBehaviour
{
    private bool toolTipIsActive;

    [ComponentInject] private ITooltipUIText CallingTooltipBahaviour;

    private void Awake()
    {
        this.ComponentInject();
    }

    private bool quiting;
    void OnApplicationQuit()
    {
        quiting = true;
    }

    public void OnDestroy()
    {
        if (toolTipIsActive && !quiting)
        {
            RemoveTooltip();
        }
    }

    void OnMouseOver()
    {
        if (TooltipSystem.instance != null && Input.GetMouseButtonDown(1))
        {
            TryActivateTooltip();
        }
    }

    private void TryActivateTooltip()
    {
        if(!toolTipIsActive && TimeTooltipRemoved.EnoughTimeForNewEvent())
        {
            var header = CallingTooltipBahaviour.GetHeaderText();
            var content = CallingTooltipBahaviour.GetContentText();
            TooltipSystem.instance.Show(content, header, waitBeforeShowing: false, activeTooltipGo: gameObject);

            toolTipIsActive = true;
            mousePosWhenShowingTooltip = Input.mousePosition;
            TimeTooltipStarted =  DateTime.Now;
        }
    }


    private DateTime TimeTooltipStarted;
    private DateTime TimeTooltipRemoved;
    private Vector2 mousePosWhenShowingTooltip;

    private void RemoveTooltip()
    {
        TooltipSystem.instance.Hide(ignoreWaitBuffer: true);
        toolTipIsActive = false;
        TimeTooltipRemoved = DateTime.Now;
    }

    public void Update()
    {
        if (!toolTipIsActive)
        {
            return;
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            && TimeTooltipStarted.EnoughTimeForNewEvent(ms: 20)
            && TimeTooltipRemoved.EnoughTimeForNewEvent(ms: 20))
        {
            RemoveTooltip();            
        }

        if (Vector2.Distance(Input.mousePosition, mousePosWhenShowingTooltip) > 100)
        {
            RemoveTooltip();
        }
    }
}