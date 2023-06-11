using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipCanvas : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    public string Header;
    public string Content;

    private Vector2 PositionMouseOnStartTooltip;

    private bool activeTooltip;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (TooltipSystem.instance != null && eventData.button == PointerEventData.InputButton.Right) 
        {
            if (!activeTooltip)
            {
                PositionMouseOnStartTooltip = Input.mousePosition;
                ShowTooltip();
                activeTooltip = true;
            }
            else
            {
                StopTooltip();
            }
        }
    }

    public void Update()
    {
        if(!activeTooltip)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopTooltip();
        }

        if(Vector2.Distance(PositionMouseOnStartTooltip, Input.mousePosition) > 50)
        {
            StopTooltip();
        }
    }

    protected virtual void ShowTooltip()
    {
        TooltipSystem.instance.Show(Content, Header, waitBeforeShowing: false);
    }

    private void StopTooltip()
    {
        TooltipSystem.instance?.Hide(ignoreWaitBuffer: true);
        activeTooltip = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopTooltip();
    }

    private bool quiting;
    private void OnApplicationQuit()
    {
        quiting = true;
    }

    private void OnDestroy()
    {
        if (!quiting)
        {
            TooltipSystem.instance?.Hide(ignoreWaitBuffer: true);
            activeTooltip = false;
        }
    }
}
