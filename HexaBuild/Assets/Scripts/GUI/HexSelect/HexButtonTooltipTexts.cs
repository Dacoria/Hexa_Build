using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HexButtonTooltipTexts
{
    public static TooltipTexts Generate(HexStateType state)
    {
        var header = state.ToString();
        var content = new List<string>();
        var rscCosts = state.Props().RscCostsToGetInState;

        if (rscCosts.Any())
        {

            content.Add("Cost:");
            foreach (var rscCost in rscCosts)
            {
                content.Add("- " + rscCost.Type + ": " + rscCost.Amount);
            }
        }
        else
        {
            content.Add("Cost: Free");
        }

        if(state.Props().HasRscGains())
        {
            var rscGainsProp = state.Props() as IRscGainsInState;
            var rscGains = rscGainsProp.RscGainsInState;

            if (rscGains != null && rscGains.Any())
            {
                content.Add("");
                content.Add("Gains:");
                foreach (var rscGain in rscGains)
                {
                    content.Add("- " + rscGain.Type + ": " + rscGain.Amount);
                }
            }
        }

        

        return new TooltipTexts(header, content);
    }
}