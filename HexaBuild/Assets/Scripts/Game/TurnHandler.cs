using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public partial class TurnHandler : BaseEventCallback
{
    public static TurnHandler instance;
    [HideInInspector] public int CurrentTurn;
    public List<ResourceAmount> ResourcesOnNewTurn;

    private new void Awake()
    {
        base.Awake();
        instance = this;
        CurrentTurn = 1;
    }

    public void NextTurn()
    {
        CurrentTurn++;
        ResourceHandler.instance.AddResources(ResourcesOnNewTurn);

        AE.NewTurn?.Invoke(CurrentTurn);
    }
}