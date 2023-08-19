using System.Collections.Generic;
using System.Linq;

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
            new ResourceAmount(10, RscType.Food),
        };
        ResourceHandler.instance.SetInitResources(startResources);

        HexGrid.instance.LoadGrid();
    }
}