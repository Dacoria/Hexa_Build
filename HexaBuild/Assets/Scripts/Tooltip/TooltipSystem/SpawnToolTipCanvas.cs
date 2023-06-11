using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnToolTipCanvas : MonoBehaviour
{
    public GameObject ToolTipPrefab;

    private void Start()
    {
        AE.GridLoaded += OnGridLoaded;       
    }

    private void OnGridLoaded()
    {
        Instantiate(ToolTipPrefab);
    }

    private void OnDestroy()
    {
        AE.GridLoaded -= OnGridLoaded;
    }
}