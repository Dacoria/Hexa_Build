using System;

[Serializable]
public class ResourceAmount
{
    public int Amount;
    public RscType Type;

    public ResourceAmount(int amount, RscType type)
    {
        Amount = amount;
        Type = type;
    }

    public ResourceAmount(RscType type, int amount)
    {
        Amount = amount;
        Type = type;
    }
}