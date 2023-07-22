using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentTurnView : BaseEventCallbackSlowUpdate
{
    [ComponentInject] private TMP_Text text;

    protected override void SlowUpdate()
    {
        text.text = "Turn: " + TurnHandler.instance.CurrentTurn;
    }
}
