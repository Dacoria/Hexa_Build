using System.Collections.Generic;

public class LoadingDisplayShowerScript : BaseEventCallbackSlowUpdate
{
    private void Start()
    {
        Settings.UserInterfaceIsLocked = true;
    }

    protected override void SlowUpdate()
    {
        transform.GetChild(0).gameObject.SetActive(Settings.UserInterfaceIsLocked);
    }

    protected override void OnGridLoaded()
    {
        Settings.UserInterfaceIsLocked = false;
    }
}