using System.Collections.Generic;
using UnityEngine;

public class GameTextManager : BaseEventCallback
{
    protected override void OnGridLoaded()
    {
        var text = "";
        text += ("== START GAME ==");

        Textt.GameLocal(text);
    }
}
