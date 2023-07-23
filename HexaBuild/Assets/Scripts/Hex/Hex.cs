using System.Linq;
using System.Collections;
using UnityEngine;

[SelectionBase]
public class Hex : BaseEventCallback
{
    [ComponentInject] private HexCoordinates hexCoordinates;
    [ComponentInject] private HighlightHexScript highlightMove;

    public Vector3Int HexCoordinates => hexCoordinates.OffSetCoordinates;
    public HexStateType HexStateType;
    public int HexStateLevel;

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

    public void ChangeState(HexStateType state)
    {
        hexSurfaceScript.HexSurfaceTypeChanged(state.Props().Surface);
        hexObjectOnTileScript.HexObjectOnTileTypeChanged(state.Props().ObjectOnTile, state.Props().HexGrowthLevel());

        Destroy(GetComponent<RscGainBehaviour>());
        Destroy(GetComponent<RscGrowthBehaviour>());
        if (state.Props().HasRscGrowth())
        {
            gameObject.AddComponent<RscGrowthBehaviour>();
        }

        HexStateType = state;
    }

    public void ChangeStateLevel(int newLevel)
    {
        hexObjectOnTileScript.HexObjectOnTileTypeChanged(HexStateType.Props().ObjectOnTile, newLevel);
        HexStateLevel = newLevel;

        if (newLevel == 4 && HexStateType.Props().HasRscGains())
        {
            gameObject.AddComponent<RscGainBehaviour>();

            var structureGo = this.GetStructuresGo();
            
            if (Load.GoMap.TryGetValue("BuildingAxe", out GameObject result1))
            {
                var go = Instantiate(result1, structureGo.transform);
                go.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}