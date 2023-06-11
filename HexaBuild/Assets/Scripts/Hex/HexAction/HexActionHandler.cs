using UnityEngine;

public partial class HexActionHandler : MonoBehaviour
{
    public static HexActionHandler instance;

    private void Awake()
    {
        instance = this;
    }
}