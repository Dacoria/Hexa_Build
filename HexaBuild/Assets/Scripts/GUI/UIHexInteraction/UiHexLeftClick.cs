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
        if (hexSelected.HexSurfaceType.IsBarren())
        {
            ShowHexButtonsHandler.instance.LoadSurfaceButtons(hexSelected);
        }
        else if (HexMutateHandler.instance.CanCreateHexSurface(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadScoutButtons(hexSelected);
        }
        else if (HexMutateHandler.instance.CanBuildOnHex(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadBuildButtons(hexSelected);
        }
        else if (HexMutateHandler.instance.CanPlantOnSoilHex(hexSelected))
        {
            ShowHexButtonsHandler.instance.LoadPlantSoilButtons(hexSelected);
        }
        else if (HexMutateHandler.instance.CanHarvestSoilObjOnHex(hexSelected, checkResources: false))
        {
            ShowHexButtonsHandler.instance.LoadHarvestSoilButtons(hexSelected);
        }
        else
        {
            hexSelected.EnableHighlight(HighlightColorType.Cyan);
        }
    }
}