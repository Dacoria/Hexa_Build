using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceHandler: MonoBehaviour
{
    public static ResourceHandler instance;
    private List<ResourceAmount> currentResources;
    public IReadOnlyList<ResourceAmount> CurrentResourcesRO => currentResources.AsReadOnly();

    private void Awake()
    {
        this.ComponentInject();
        instance = this;       
        currentResources = new List<ResourceAmount>();
    }

    public void SetInitResources(List<ResourceAmount> startingResources)
    {
        currentResources = startingResources;
    }

    public void AddResources(List<ResourceAmount> rscsToAdd)
    {
        foreach (var resource in rscsToAdd)
        {
            AddResource(resource.Type, resource.Amount);
        }
    }

    public void AddResource(RscType type, int amount)
    {
        var resource = currentResources.Single(x => x.Type == type);
        resource.Amount += amount;        
    }

    public void RemoveResources(List<ResourceAmount> rscsToRemove)
    {
        foreach (var resource in rscsToRemove)
        {
            RemoveResource(resource.Type, resource.Amount);
        }
    }

    public void RemoveResource(RscType type, int amount)
    {
        var resourceInStock = currentResources.Single(x => x.Type == type);
        resourceInStock.Amount -= amount;
    }

    public bool HasResourcesForUse(List<ResourceAmount> resourceCosts)
    {
        foreach (var resourceCost in resourceCosts)
        {
            var resourceTypeInStock = currentResources.Single(x => x.Type == resourceCost.Type);
            if (resourceTypeInStock.Amount < resourceCost.Amount)
            {
                return false;
            }
        }

        return true;
    }
}