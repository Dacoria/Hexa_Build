using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using UnityEngine.UI;

public class ResourceViewScript : MonoBehaviour
{
    public RscType ResourceType;
    [ComponentInject] private TMP_Text text;
    [ComponentInject] private Image image;

    private void Awake()
    {
        this.ComponentInject();
    }

    public void SetType(RscType resourceType)
    {
        ResourceType = resourceType;
        image.sprite = Load.SpriteMap.Get(resourceType.ToString());
    }

    public void UpdateAmountInText(int amount)
    {
        text.text = ResourceType.ToString() + ": " + amount;
    }

    public void Click()
    {
        ResourceHandler.instance.AddResource(ResourceType, 10);
    }
}
