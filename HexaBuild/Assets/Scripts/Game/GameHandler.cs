using UnityEngine;

public partial class GameHandler : BaseEventCallback
{
    public static GameHandler instance;


    public GameStatus GameStatus;

    private new void Awake()
    {
        base.Awake();
        instance = this;
        GameStatus = GameStatus.NotStarted;
    }
}