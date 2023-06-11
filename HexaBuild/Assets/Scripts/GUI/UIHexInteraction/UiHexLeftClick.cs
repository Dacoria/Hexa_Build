using UnityEngine;
using UnityEngine.EventSystems;

public class UiHexLeftClick : MonoBehaviour
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

    private static void ClickOnTile(Hex hexSelected)
    {                  
        hexSelected.EnableHighlight(HighlightColorType.Green);

        if (HexActionHandler.instance.CanChangeHexSurface(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadChangeHexSurfaceButtons(hexSelected);
            return;
        }

        if (HexActionHandler.instance.CanScoutHex(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadScoutButtons(hexSelected);
            return;
        }

        if (HexActionHandler.instance.CanBuildOnHex(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadBuildButtons(hexSelected);
            return;
        }

        if (HexActionHandler.instance.CanPlantOnSoilHex(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadPlantSoilButtons(hexSelected);
            return;
        }

        if (HexActionHandler.instance.CanHarvestSoilObjOnHex(hexSelected, checkResources: false))
        {
            ShowHexButtonsHandler.instance.LoadHarvestSoilButtons(hexSelected);
            return;
        }

        hexSelected.EnableHighlight(HighlightColorType.Cyan);
    }
}