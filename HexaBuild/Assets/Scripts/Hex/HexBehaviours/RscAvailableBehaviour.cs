using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RscAvailableBehaviour : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    public RscType RscType { get; private set; }
    public int ResourcesAvailable { get; private set; }

    private void Start()
    {
        var props = hex.HexStateType.Props() as IRscInState;
        RscType = props.RscType;
        ResourcesAvailable = props.RscAvailableInit;
    }

    protected override void OnHexStateChanged(Hex hex)
    {
        if (this.hex == hex)
        {
            Destroy(this);
        }
    }

    public void SetRscAvailable(int newValue)
    {
        ResourcesAvailable = newValue;
    }

    public bool CanRetrieveFullRscAmount(int amount) => amount <= ResourcesAvailable;

    public int RetrieveRscAmount(int amount, bool onlyFullResourceAmount)
    {
        if(CanRetrieveFullRscAmount(amount))
        {
            ResourcesAvailable -= amount;
            return amount;
        }
        else
        {
            if(onlyFullResourceAmount)
            {
                return 0;
            }
            else
            {
                var rscRetrieved = ResourcesAvailable;
                ResourcesAvailable = 0;
                return rscRetrieved;
            }
        }
    }
}
