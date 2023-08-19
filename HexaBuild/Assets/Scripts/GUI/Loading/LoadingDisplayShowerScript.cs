using System.Collections.Generic;

public class LoadingDisplayShowerScript : BaseEventCallbackSlowUpdate
{
    private bool gameOver;

    protected override void SlowUpdate()
    {
        if (gameOver)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(Settings.UserInterfaceIsLocked);
        }
    }

    protected override void OnGameOver() => gameOver = true;

}