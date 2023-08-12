using System.Linq;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class Hex : BaseEventCallback
{
    [ComponentInject] private HexCoordinates hexCoordinates;
    [ComponentInject] private HighlightHexScript highlightMove;

    public Vector3Int HexCoordinates => hexCoordinates.OffSetCoordinates;

    #region HexStateType get+set+event
    [SerializeField] private HexStateType _hexStateType; // serializable, want editor changes....
    public HexStateType HexStateType { 
        get => _hexStateType;
        set 
        {
            _hexStateType = value;
            if (!Utils.IsEditor())
            {
                ChangeState();
                AE.HexStateChanged?.Invoke(this);
            }
        }
    }
#endregion

    #region HexStateLevel get+set+event
    [SerializeField] private int _hexStateLevel; // serializable, want editor changes....
    public int HexStateLevel
    {
        get => _hexStateLevel;
        set
        {
            _hexStateLevel = value;
            if (!Utils.IsEditor())
            {
                ChangeStateLevel();
                AE.HexStateLevelChanged?.Invoke(this);
            }
        }
    }
#endregion

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

    private void ChangeState()
    {
        var state = HexStateType;        

        if (state.Props().HasRsc())
        {
            gameObject.AddComponent<RscAvailableBehaviour>();
        }
        if (state.Props().HasRscGrowth())
        {
            gameObject.AddComponent<RscGrowthBehaviour>();
        }
        if(state == HexStateType.Stones)
        {
            gameObject.AddComponent<StoneGainBehaviour>();
        }

        hexSurfaceScript.HexSurfaceTypeChanged(state.Props().Surface);
        HexStateLevel = this.CalcHexStateLevel(); // forceert obj on tile wijziging

        // Verplaatsen naar build buttons tzt
                
    }

    private void ChangeStateLevel()
    {        
        hexObjectOnTileScript.HexObjectOnTileTypeChanged(HexStateType.Props().ObjectOnTile, HexStateLevel);

        // Verplaatsen naar build buttons tzt
        if (HexStateLevel == 4 && HexStateType.Props().HasRscGains() && HexStateType == HexStateType.Trees)
        {
            AddRscGainObjects("BuildingAxe");
        }
        if (HexStateLevel == 3 && HexStateType.Props().HasRscGains() && HexStateType == HexStateType.Wheats)
        {
            AddRscGainObjects("BuildingScythe");
        }
        if (HexStateLevel >= 101 && HexStateType.Props().HasRscGains() && HexStateType == HexStateType.Stones)
        {
            // elke x opnieuw aanmaken :S
            AddRscGainObjects("BuildingPickAxe");
        }
    }

    private void AddRscGainObjects(string objToSummon)
    {
        gameObject.AddComponent<RscGainBehaviour>();

        var structureGo = this.GetStructuresGo();

        if (Load.GoMap.TryGetValue(objToSummon, out GameObject result1))
        {
            var go = Instantiate(result1, structureGo.transform);
            go.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }
}