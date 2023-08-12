using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StoneGainBehaviour : BaseEventCallbackSlowUpdate
{
    [ComponentInject] private Hex hex;
    [ComponentInject] private RscAvailableBehaviour rscAvailableBehaviour;

    private int initRsc;
    private int stoneStateLevel;

    private void Start()
    {
        initRsc = rscAvailableBehaviour.ResourcesAvailable;
    }

    protected override void OnHexStateChanged(Hex hex)
    {
        if (this.hex == hex && hex.HexStateType != HexStateType.Stones)
        {
            Destroy(this);
        }
    }

    public int GetStoneStateLevel() => stoneStateLevel;

    protected override void SlowUpdate()
    {
        var percRscUsed = 1f * rscAvailableBehaviour.ResourcesAvailable / initRsc;

        if(percRscUsed > 0.8)
        {
            stoneStateLevel = 101;
        }
        else if (percRscUsed > 0.6)
        {
            stoneStateLevel = 102;
        }
        else if (percRscUsed > 0.4)
        {
            stoneStateLevel = 103;
        }
        else if (percRscUsed > 0.2)
        {
            stoneStateLevel = 104;
        }
        else
        {
            stoneStateLevel = 105;
        }

        if(hex.HexStateLevel != stoneStateLevel)
        {
            hex.HexStateLevel = stoneStateLevel;
        }
    }  
}
