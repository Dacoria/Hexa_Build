using TMPro;

public class CurrentTurnView : BaseEventCallback
{
    [ComponentInject] private TMP_Text text;

    private void Start()
    {
        text.text = "Turn: " + TurnHandler.instance.CurrentTurn;
    }

    protected override void OnNewTurn()
    {
        text.text = "Turn: " + TurnHandler.instance.CurrentTurn;
    }   
}
