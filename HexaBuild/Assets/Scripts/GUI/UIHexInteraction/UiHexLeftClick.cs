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
            HexSurfaceButtonsHandler.instance.RemoveSurfaceButtons();
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
            //Debug.Log("CLICK ON START HEX (Castle) " + hexSelected.gameObject.name);
            hexSelected.EnableHighlight(HighlightColorType.Cyan);
        }
        else
        {
            if(hexSelected.FogIsActive())
            {
                hexSelected.EnableHighlight(HighlightColorType.Red);
            }
            else
            {
                hexSelected.EnableHighlight(HighlightColorType.Green);
                if (hexSelected.CanChangeSurfaceType())
                {
                    HexSurfaceButtonsHandler.instance.LoadSurfaceButtons(hexSelected);
                }
            }

            //Debug.Log("CLICK ON HEX " + hexSelected.gameObject.name);
        }
    }
}