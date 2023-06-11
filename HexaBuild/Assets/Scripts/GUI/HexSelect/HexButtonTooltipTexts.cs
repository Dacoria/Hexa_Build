using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HexButtonTooltipTexts
{
    public static TooltipTexts Generate(string header, List<ResourceAmount> rscCosts, List<ResourceAmount> rscGains = null)
    {
        var content = new List<string>();

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

        if (rscGains != null && rscGains.Any())
        {
            content.Add("");
            content.Add("Gains:");
            foreach (var rscGain in rscGains)
            {
                content.Add("- " + rscGain.Type + ": " + rscGain.Amount);
            }
        }

        return new TooltipTexts(header, content);
    }
}