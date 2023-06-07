using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public abstract class BaseEventCallback : MonoBehaviour
{
    protected void Awake()
    {
        this.ComponentInject();
    }

    protected void OnEnable()
    {
        if (IsOverwritten("OnGridLoaded")) AE.GridLoaded += OnGridLoaded;    
    }

    protected void OnDisable()
    {
        if (IsOverwritten("OnGridLoaded")) AE.GridLoaded -= OnGridLoaded;
    }
    protected virtual void OnGridLoaded() { }  
    

    // GEEN ABSTRACTE CLASSES!
    private bool IsOverwritten(string functionName)
    {
        var type = GetType();
        var method = type.GetMember(functionName, BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance);
        return method.Length > 0;
    }
}