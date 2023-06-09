using UnityEngine;
using UnityEngine.EventSystems;

public class UiHexLeftClick : MonoBehaviour
{

    private void Awake()
    {

    }

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
            HexButtonsHandler.instance.RemoveAllButtons();
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
            if(hexSelected.FogIsActive())
            {
                hexSelected.EnableHighlight(HighlightColorType.Blue);
                HexButtonsHandler.instance.LoadDiscoverButtons(hexSelected);

            }
            else
            {
                hexSelected.EnableHighlight(HighlightColorType.Green);
                if (hexSelected.CanChangeSurfaceType())
                {
                    HexButtonsHandler.instance.LoadSurfaceButtons(hexSelected);
                }
            }
        }
    }
}