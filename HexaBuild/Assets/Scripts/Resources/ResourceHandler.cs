using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceHandler: BaseEventCallback
{
    public static ResourceHandler instance;
    private List<ResourceAmount> currentResources;
    public IReadOnlyList<ResourceAmount> CurrentResourcesRO => currentResources.AsReadOnly();

    private new void Awake()
    {
        base.Awake();
        instance = this;       
        currentResources = new List<ResourceAmount>();
    }

    public void SetInitResources(List<ResourceAmount> startingResources)
    {
        currentResources = startingResources;
    }

    public void AddResources(List<ResourceAmount> rscsToAdd) => rscsToAdd.ForEach(x => AddResource(x.Type, x.Amount));

    public void AddResource(RscType type, int amount)
    {
        if (amount <= 0) { throw new System.Exception(); }
        var resource = currentResources.Single(x => x.Type == type);
        resource.Amount += amount;        
    }

    public void RemoveResources(List<ResourceAmount> rscsToRemove) => rscsToRemove.ForEach(x => RemoveResource(x.Type, x.Amount));

    public void RemoveResource(RscType type, int amount)
    {
        if(amount <= 0) { throw new System.Exception(); }
        var resourceInStock = currentResources.Single(x => x.Type == type);
        resourceInStock.Amount -= amount;
    }

    public bool HasResourcesToSpendInStock(List<ResourceAmount> resourceCosts)
    {
        if (resourceCosts == null) { return false; }

        foreach (var resourceCost in resourceCosts)
        {
            if (resourceCost.Amount < 0) { throw new System.Exception(); }

            var resourceTypeInStock = currentResources.Single(x => x.Type == resourceCost.Type);
            if (resourceTypeInStock.Amount < resourceCost.Amount)
            {
                return false;
            }
        }

        return true;
    }
}