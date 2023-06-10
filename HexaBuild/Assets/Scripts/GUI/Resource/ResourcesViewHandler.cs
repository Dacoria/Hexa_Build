using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourcesViewHandler : BaseEventCallbackSlowUpdate
{
    public ResourceViewScript ResourceInfoPrefab;
    private List<ResourceViewScript> activeResourceInfoView = new List<ResourceViewScript>();

    [ComponentInject] private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup.alpha = 0;
    }

    protected override void OnGridLoaded() => LoadResourceInfo();

    public void LoadResourceInfo()
    {
        foreach (ResourceType resourceType in Enum.GetValues(typeof(ResourceType)))
        {
            var rscInfoGo = Instantiate(ResourceInfoPrefab, transform);
            rscInfoGo.SetType(resourceType);
            activeResourceInfoView.Add(rscInfoGo);
        }

        MonoHelper.instance.FadeIn(canvasGroup, 1f);
    }

    protected override void SlowUpdate()
    {
        if (canvasGroup.alpha > 0)
        {
            foreach (var resourceInfo in activeResourceInfoView)
            {
                var amount = ResourceHandler.instance.CurrentResourcesRO.Single(x => x.Type == resourceInfo.ResourceType).Amount;
                resourceInfo.UpdateAmountInText(amount);
            }
        }
    }
}
