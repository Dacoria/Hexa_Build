using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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
            new ResourceAmount(25, RscType.Energy),
            new ResourceAmount(15, RscType.Mana),
            new ResourceAmount(5, RscType.Wood),
            new ResourceAmount(3, RscType.Stone),
        };
        ResourceHandler.instance.SetInitResources(startResources);

        HexGrid.instance.LoadGrid();
    }
}