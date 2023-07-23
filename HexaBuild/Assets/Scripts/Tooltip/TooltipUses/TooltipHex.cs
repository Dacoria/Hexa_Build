using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TooltipHex : MonoBehaviour, ITooltipUIText
{
    [ComponentInject] private Hex hex;

    public void Awake()
    {
        this.ComponentInject();
        gameObject.AddComponent<TooltipUIHandler>(); // regelt het tonen vd juiste text + gedrag -> via ITooltipUIText
    }

    public string GetHeaderText() => "Hex";
    public string GetContentText()
    {
        RscAvailableBehaviour rscAvailableBehaviour = GetComponent<RscAvailableBehaviour>();
        RscGrowthBehaviour rscGrowthBehaviour = GetComponent<RscGrowthBehaviour>();
        RscGainBehaviour rscGainBehaviour = GetComponent<RscGainBehaviour>();


        var result = new Dictionary<string, string>();
        result.Add("HexStateType", hex.HexStateType.ToString());
        result.Add("HexStateLevel", hex.HexStateLevel.ToString());

        if(rscAvailableBehaviour != null)
        {
            result.Add("Rsc type", rscAvailableBehaviour.RscType.ToString());
            result.Add("Rsc available", rscAvailableBehaviour.ResourcesAvailable.ToString());
        }
        if (rscGrowthBehaviour != null)
        {
            if(rscGrowthBehaviour.HasNextLevelGrowth())
            {
                result.Add("Rsc amount next level", rscGrowthBehaviour.GetRscAmountOnGrowthLevel(hex.HexStateLevel + 1).ToString());
            }
            else
            {
                result.Add("Growth stopped", "Limit reached");
            }
        }

        if (rscGainBehaviour != null)
        {
            var props = hex.HexStateType.Props() as IRscGainsInState;
            result.Add("Rsc gained per turn", props.RscCostGainsInStatePerTurn.Gains.Amount.ToString());
        }

        return string.Join("\n", result.Select(x => x.Key + ": " + x.Value));
    }
}
