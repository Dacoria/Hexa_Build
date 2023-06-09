﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HexButtonTooltipTexts
{
    public static TooltipTexts Generate(HexStateType state, HexSelectCategoryType category)
    {
        var header = state.ToString() + " - " + category.ToString();
        var content = new List<string>();

        switch(category)
        {
            case HexSelectCategoryType.StateChange:
                AddRscCostsToText(content, state.Props().RscCostsToGetInState);
                break;
            case HexSelectCategoryType.GainRsc:
                var props = state.Props() as IRscGainsInState;
                AddRscCostsToText(content, props.RscCostGainsInState.Costs);
                content.Add("");
                AddRscGainsToText(content, props.RscCostGainsInState.Gains);
                break;
            default:
                throw new Exception("");
        }

        return new TooltipTexts(header, content);
    }

    private static void AddRscCostsToText(List<string> content, List<ResourceAmount> rscCosts)
    {
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
    }

    private static void AddRscGainsToText(List<string> content, List<ResourceAmount> rscGains)
    {
        if (rscGains.Any())
        {
            content.Add("Gains:");
            foreach (var rscGain in rscGains)
            {
                content.Add("- " + rscGain.Type + ": " + rscGain.Amount);
            }
        }
        else
        {
            content.Add("No Gains");
        }
    }
}