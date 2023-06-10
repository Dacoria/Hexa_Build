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
        if (hexSelected.HexObjectOnTileType != HexObjectOnTileType.None)
        {
            // geen leeg veld? dan niet selecten
            hexSelected.EnableHighlight(HighlightColorType.Cyan);
        }
        else
        {            
            hexSelected.EnableHighlight(HighlightColorType.Green);
            if (hexSelected.HexSurfaceType.IsBarren())
            {
                ShowHexButtonsHandler.instance.LoadSurfaceButtons(hexSelected);
            }
            else if (hexSelected.CanBeDiscovered())
            {
                ShowHexButtonsHandler.instance.LoadScoutButtons(hexSelected);
            }
            else if (hexSelected.CanBuildOn())
            {
                ShowHexButtonsHandler.instance.LoadBuildButtons(hexSelected);
            }
            else if (hexSelected.CanUseSoilOn())
            {
                ShowHexButtonsHandler.instance.LoadUseSoilButtons(hexSelected);
            }

        }
    }
}