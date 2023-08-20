using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HexGrid : BaseEventCallback
{
    private Dictionary<Vector3Int, Hex> hexTileDict = new Dictionary<Vector3Int, Hex>();

    public static HexGrid instance;

    private HexNeighbours hexNeighbours = new HexNeighbours();
    public bool GridIsLoaded;

    private new void Awake()
    {
        base.Awake();
        instance = this;
    }

    public void LoadGrid()
    {
        var hexes = FindObjectsOfType<Hex>();        
        var hexesSorted = hexes.OrderBy(x => Vector3.Distance(x.transform.position, new Vector3(0,0,0))).ToList();

        var counter = 0;
        foreach (var hex in hexesSorted)
        {
            counter++;
            hex.gameObject.name = "Hex" + counter; // naam van go
            hex.transform.SetSiblingIndex(counter - 1); // volgorde in hierarchie

            if (hexTileDict.ContainsKey(hex.HexCoordinates))
            {
                throw new Exception(hex.gameObject.name + " + " + hexTileDict[hex.HexCoordinates].gameObject.name);
            }

            if (hex.transform.GetChild(0).childCount != 1)
            {
                throw new Exception(hex.gameObject.name + " heeft meerdere tiles" );
            }    

            hexTileDict[hex.HexCoordinates] = hex;

            var lerp = hex.gameObject.AddComponent<LerpMovement>();
            lerp.MoveToDestination(hex.transform.position, duration: 1.5f, startPosition: hex.transform.position + new Vector3(0, -100, 0), delayedStart: hex.transform.position.x * 0.08f);
        }
    }

    public void CreateNewHex(Vector3Int coordinates)
    {
        var hexPrefab = Load.GoMap.Get("Hex");
        var hexGo = Instantiate(hexPrefab, coordinates.ConvertCoordinatesToPosition(), Quaternion.identity, transform);
        var hexScript = hexGo.GetComponent<Hex>();

        hexTileDict[hexScript.HexCoordinates] = hexScript;

        var hexForestPrefab = Load.GoMap.Get("hex_forest");
        var mainGo = Utils.GetMainGo(hexScript);
        Instantiate(hexForestPrefab, mainGo.transform);

        hexScript.HexStateType = HexStateType.Barren;

        var lerp = hexGo.AddComponent<LerpMovement>();
        lerp.MoveToDestination(hexGo.transform.position, duration: 1.5f, startPosition: hexGo.transform.position + new Vector3(0, -100, 0));
    }

    private bool HexGridLoaded;

    private void Update()
    {
        if(!HexGridLoaded)
        {
            HexGridLoaded = hexTileDict.Values.All(x => Vector3.Distance(x.OrigPosition, x.transform.position) < 0.01f);
            if(HexGridLoaded)
            {
                AE.GridLoaded?.Invoke();
            }
        }
    }    

    public List<Vector3Int> GetNeighboursFor(Vector3Int hexCoordinates, int range = 1, bool showOnlyVisibleTiles = true, bool includeStartHex = false)
    {
        return hexNeighbours.GetNeighboursFor(
            hexTileDict: hexTileDict,
            hexCoordinates: hexCoordinates,
            range: range,
            showOnlyVisibleTiles: showOnlyVisibleTiles,
            includeStartHex: includeStartHex
        );
    }

    public List<Vector3Int> GetFreePlacesDirectlyAroundHex(Vector3Int hexCoordinates)
    {
        return hexNeighbours.GetFreePlacesDirectlyAroundHex(
            hexTileDict: hexTileDict,
            hexCoordinates: hexCoordinates
        );
    }

    public void DisableAllHighlightsOnHex()
    {
        foreach (var hex in hexTileDict.Values)
        {
            hex.DisableHighlight();
        }
    }

    public Hex GetHexAt(Vector3Int hexCoordinates)
    {
        Hex result = null;
        hexTileDict.TryGetValue(hexCoordinates, out result);
        return result;
    } 
}