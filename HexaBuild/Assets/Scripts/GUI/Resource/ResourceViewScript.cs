using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ResourceViewScript : MonoBehaviour
{
    public ResourceType ResourceType;
    [ComponentInject] private TMP_Text text;

    private void Awake()
    {
        this.ComponentInject();
    }

    private void Update()
    {
        var amount = ResourceHandler.instance.CurrentResourcesRO.Single(x => x.Type == ResourceType).Amount;
        text.text = ResourceType.ToString() + ": " + amount;
    }
}
