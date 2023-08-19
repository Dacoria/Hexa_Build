using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;

public class RscAvailableBehaviour : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    public int ResourcesAvailable { get; private set; }

    private void Start()
    {
        var props = hex.HexStateType.Props() as IRscInState;
        ResourcesAvailable = props.RscAvailableInit;
    }

    protected override void OnHexStateChanged(Hex hex)
    {
        if (this.hex == hex && !hex.HexStateType.Props().HasRsc())
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
