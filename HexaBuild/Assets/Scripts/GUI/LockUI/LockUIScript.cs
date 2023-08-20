using System.Collections.Generic;

public class LockUIScript : BaseEventCallback
{    
    private void Start()
    {
        Settings.UserInterfaceIsLocked = true;
    }   

    protected override void OnGridLoaded() => Settings.UserInterfaceIsLocked = false;
    protected override void OnGameOver() => Settings.UserInterfaceIsLocked = true;
}