using System;
using UnityEngine;

public interface IHexButtonScript
{
    void SetHexValue<T>(T type, Hex relatedHex) where T : Enum;
    GameObject GetGo();
    TooltipTexts GetTooltipTexts();
}