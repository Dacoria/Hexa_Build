using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiHexLeftClick : BaseEventCallback
{
    void Update()
    {  
        if(Settings.UserInterfaceIsLocked)
        {
            return;
        }
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }     

        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            HexGrid.instance.DisableAllHighlightsOnHex();
            ShowHexButtonsHandler.instance.RemoveAllButtons();
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            if (UiHoverOverHex.Instance.HexHoveredOver != null)
            {
                ClickOnTile(UiHoverOverHex.Instance.HexHoveredOver);
            }
            else
            {
                //Debug.Log("CLICK ON NOTHING!");                
            }
        }
    }

    protected override void OnNewTurn(int turn) => HexGrid.instance.DisableAllHighlightsOnHex();


    private static void ClickOnTile(Hex hexSelected)
    {                  
        if(hexSelected.HexStateType == HexStateType.Transparent)
        {
            return;
        }

        hexSelected.EnableHighlight(HighlightColorType.Green);
        var allowedNextStates = hexSelected.HexStateType.Props().PossibleNextStateTypes(hexSelected);

        if(allowedNextStates.Any())
        {
            ShowHexButtonsHandler.instance.LoadHexSelectButtons(hexSelected);
            return;
        }

        hexSelected.EnableHighlight(HighlightColorType.Cyan);
    }
}