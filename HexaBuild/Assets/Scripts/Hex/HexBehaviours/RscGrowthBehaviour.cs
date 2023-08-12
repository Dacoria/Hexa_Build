using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RscGrowthBehaviour : BaseEventCallback
{
    [ComponentInject] private Hex hex;
    [ComponentInject] private RscAvailableBehaviour rscAvailableBehaviour;

    private void Start()
    {        
        var props = hex.HexStateType.Props() as IRscGrowthInState;
        hex.HexStateLevel = props.RscGrowthLevels.Min(x => x.Level);
    }

    protected override void OnHexStateChanged(Hex hex)
    {
        if (this.hex == hex && !hex.HexStateType.Props().HasRscGrowth())
        {
            Destroy(this);
        }
    }

    protected override void OnNewTurn()
    {
        if (HasNextLevelGrowth())
        {
            hex.HexStateLevel = GetNextLevelGrowth();
        }        
    }

    public int GetRscAmountOnGrowthLevel(int level)
    {
        var props = hex.HexStateType.Props() as IRscGrowthInState;
        return props.RscGrowthLevels.Single(x => x.Level == level).CountRscAvailable;
    }

    public bool HasNextLevelGrowth() => GetNextLevelGrowth() == hex.HexStateLevel + 1;

    public int GetNextLevelGrowth()
    {
        if (hex.GetComponent<RscGainBehaviour>() != null)
        {
            return -1;
        }

        var props = hex.HexStateType.Props() as IRscGrowthInState;

        var currentLevel = hex.HexStateLevel;
        if (props.RscGrowthLevels.Any(x => x.Level == currentLevel + 1))
        {
            return currentLevel + 1;
        }

        return currentLevel;
    }

    protected override void OnHexStateLevelChanged(Hex hex)
    {
        if (hex == this.hex && hex.HexStateType.Props().HasRscGrowth())
        {
            var props = hex.HexStateType.Props() as IRscGrowthInState;
            var newRscAmountForLevel = props.RscGrowthLevels.Single(x => x.Level == hex.HexStateLevel).CountRscAvailable;
            rscAvailableBehaviour.SetRscAvailable(newRscAmountForLevel);
        }
    }
}
