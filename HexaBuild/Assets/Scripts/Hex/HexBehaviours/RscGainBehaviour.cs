using System;
using System.Collections.Generic;
using UnityEngine;

public class RscGainBehaviour : BaseEventCallback
{
    [ComponentInject] private Hex hex;
    [ComponentInject] private RscAvailableBehaviour rscAvailableBehaviour;

    protected override void OnHexStateChanged(Hex hex)
    {
        if (this.hex == hex && !hex.HexStateType.Props().HasRscGains())
        {
            Destroy(this);
        }
    }

    protected override void OnNewTurn()
    {
        var props = hex.HexStateType.Props() as IRscGainsInState;
        if(props == null) { return; }
        ProcessRscCostGains(props.RscCostGainsInStatePerTurn);
    }

    public void ManualGainRsc()
    {
        var props = hex.HexStateType.Props() as IRscGainsInState;
        ProcessRscCostGains(props.RscCostGainsInStatePerAction);
    }

    private void ProcessRscCostGains(ResourceCostGains costGainsPerTurn)
    {
        ProcesRscCosts(costGainsPerTurn);
        ProcesRscGains(costGainsPerTurn);

        if (rscAvailableBehaviour.ResourcesAvailable == 0)
        {
            NoMoreResourcesAvailableAfterRetrieval();
        }
    }

    private void ProcesRscCosts(ResourceCostGains costGainsPerTurn)
    {
        if (ResourceHandler.instance.HasResourcesForUse(costGainsPerTurn.Costs))
        {
            ResourceHandler.instance.RemoveResources(costGainsPerTurn.Costs);
        }
        else
        {
            // TODO - en als je de resouces niet hebt?!
            Debug.Log("GEEN RESOURCES OVER OM TE VERWIJDEREN?! " + hex.name);
        }
    }

    private void ProcesRscGains(ResourceCostGains costGainsPerTurn)
    {
        if (rscAvailableBehaviour.CanRetrieveFullRscAmount(costGainsPerTurn.Gains.Amount))
        {
            rscAvailableBehaviour.RetrieveRscAmount(costGainsPerTurn.Gains.Amount, onlyFullResourceAmount: true);
            ResourceHandler.instance.AddResource(costGainsPerTurn.Gains.Type, costGainsPerTurn.Gains.Amount);
        }
        else
        {
            // keuze; wat doe je als je nog 1 wood nodig hebt; maar je wilt 2 gainen? Huidig: dat maar gainen
            var amountRetrieved = rscAvailableBehaviour.RetrieveRscAmount(costGainsPerTurn.Gains.Amount, onlyFullResourceAmount: false);
            ResourceHandler.instance.AddResource(costGainsPerTurn.Gains.Type, amountRetrieved);
        }
    }    

    private void NoMoreResourcesAvailableAfterRetrieval()
    {
        var props = hex.HexStateType.Props() as IRscInState;
        hex.HexStateType = props.StateToIfNoMoreRsc;
    }
}