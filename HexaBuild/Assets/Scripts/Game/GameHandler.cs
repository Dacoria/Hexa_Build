using UnityEngine;

public partial class GameHandler : BaseEventCallback
{
    public static GameHandler instance;

    private new void Awake()
    {
        base.Awake();
        instance = this;
    }
}