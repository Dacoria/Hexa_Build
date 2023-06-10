using System.Linq;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Hex : BaseEventCallback
{
    [ComponentInject] private HexCoordinates hexCoordinates;
    [ComponentInject] private HighlightHexScript highlightMove;

    private FogOnHex fogOnHex;

    public HighlightColorType? GetHighlight() => highlightMove.CurrentColorHighlight;

    public Vector3Int HexCoordinates => hexCoordinates.OffSetCoordinates;

    public HexSurfaceType HexSurfaceType;

    public HexObjectOnTileType HexObjectOnTileType; // voor debug + setting purposes


    public Vector3 OrigPosition;

    private HexSurfaceScript hexSurfaceScript;

    public bool InitFogIsActive;
    public bool FogIsActive() => HexSurfaceType == HexSurfaceType.Simple_Water;


    new void Awake()
    {
        base.Awake();
        this.hexSurfaceScript = gameObject.AddComponent<HexSurfaceScript>();

        OrigPosition = this.transform.position;

        if(InitFogIsActive)
        {
            ChangeHexSurfaceType(HexSurfaceType.Simple_Water);
        }
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
        ChangeHexSurfaceType(HexSurfaceType.Simple_Water);
    }

    public void ChangeHexSurfaceType(HexSurfaceType changeToType, bool alsoChangeType = true)
    {
        hexSurfaceScript.HexSurfaceTypeChanged(changeToType);
        if (alsoChangeType)
        {
            HexSurfaceType = changeToType;
        }
    }
}