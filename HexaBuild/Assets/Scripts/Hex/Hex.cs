using System.Linq;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Hex : BaseEventCallback
{
    [ComponentInject] private HexCoordinates hexCoordinates;
    [ComponentInject] private HighlightHexScript highlightMove;

    public Vector3Int HexCoordinates => hexCoordinates.OffSetCoordinates;

    public HexSurfaceType HexSurfaceType;

    public HexObjectOnTileType HexObjectOnTileType; // voor debug + setting purposes


    public Vector3 OrigPosition;

    private HexSurfaceScript hexSurfaceScript;
    private HexObjectOnTileScript hexObjectOnTileScript;


    new void Awake()
    {
        base.Awake();
        this.hexSurfaceScript = gameObject.AddComponent<HexSurfaceScript>();
        this.hexObjectOnTileScript = gameObject.AddComponent<HexObjectOnTileScript>();

        OrigPosition = this.transform.position;        
    }

    public void EnableHighlight(HighlightColorType type) => highlightMove.CurrentColorHighlight = type;
    public void DisableHighlight() => highlightMove.CurrentColorHighlight = HighlightColorType.None;
    public void DisableHighlight(HighlightColorType type)
    {
        if (highlightMove.CurrentColorHighlight == type)
        {
            highlightMove.CurrentColorHighlight = HighlightColorType.None;
        }
    }

    public void DiscoverHex()
    {
        ChangeHexSurfaceType(HexSurfaceType.Barren);
    }

    public void ChangeHexSurfaceType(HexSurfaceType changeToType)
    {
        hexSurfaceScript.HexSurfaceTypeChanged(changeToType);
        HexSurfaceType = changeToType;        
    }

    public void ChangeHexObjOnTile(HexObjectOnTileType changeToType)
    {
        hexObjectOnTileScript.HexObjectOnTileTypeChanged(changeToType);
        HexObjectOnTileType = changeToType;
    }
}