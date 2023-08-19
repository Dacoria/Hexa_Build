using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public partial class TurnHandler : BaseEventCallback
{
    public static TurnHandler instance;
    [HideInInspector] public int CurrentTurn;
    [SerializeField] private List<ResourceAmount> ResourcesChangeNewTurn;

    private new void Awake()
    {
        base.Awake();
        instance = this;
        CurrentTurn = 1;
    }

    public void NextTurn()
    {
        CurrentTurn++;
        ResourceHandler.instance.AddResources(ResourcesChangeNewTurn.Where(x => x.Amount > 0).ToList());
        
        var rscsToLose = ResourcesChangeNewTurn.Where(x => x.Amount < 0).ToList();
        var rscsToLoseAbs = rscsToLose.Select(x => new ResourceAmount(x.Type, Mathf.Abs(x.Amount))).ToList();

        if (ResourceHandler.instance.HasResourcesToSpendInStock(rscsToLoseAbs))
        {
            ResourceHandler.instance.RemoveResources(rscsToLoseAbs);
            AE.NewTurn?.Invoke();
        }
        else
        {
            AE.GameOver?.Invoke();
        }
    }
}