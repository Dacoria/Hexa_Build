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
        if (Input.GetMouseButtonDown(0))
        {
            if (UiHoverOverHex.Instance.HexHoveredOver != null)
            {
                Debug.Log("CLICK ON HEX!");
            }
            else
            {
                Debug.Log("CLICK ON NOTHING!");
            }
        }
    }
}