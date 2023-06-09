using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class GameHandler : BaseEventCallback
{
    public static GameHandler instance;    

    private new void Awake()
    {
        base.Awake();
        instance = this;
    }

    private void Start()
    {
        var startResources = new List<ResourceAmount>
        {
            new ResourceAmount(25, ResourceType.Energy),
            new ResourceAmount(15, ResourceType.Mana),
            new ResourceAmount(5, ResourceType.Wood),
            new ResourceAmount(3, ResourceType.Stone),
        };
        ResourceHandler.instance.SetInitResources(startResources);

        HexGrid.instance.LoadGrid();
    }
}