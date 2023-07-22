using System.Collections.Generic;
using System.Linq;

public class RscGrowthBehaviour : BaseEventCallback
{
    [ComponentInject] private Hex hex;

    private void Start()
    {
        var props = hex.HexStateType.Props() as IRscGrowthInState;
        hex.ChangeStateLevel(props.RscPerGrowthLevel.Min(x => x.Level));
    }
    protected override void OnNewTurn(int turn)
    {
        var props = hex.HexStateType.Props() as IRscGrowthInState;

        var currentLevel = hex.HexStateLevel;
        if(props.RscPerGrowthLevel.Any(x => x.Level == currentLevel + 1))
        {
            hex.ChangeStateLevel(currentLevel + 1);
        }
    }
}
