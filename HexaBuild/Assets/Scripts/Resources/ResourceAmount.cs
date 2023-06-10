public class ResourceAmount
{
    public int Amount;
    public ResourceType Type;

    public ResourceAmount(int amount, ResourceType type)
    {
        Amount = amount;
        Type = type;
    }

    public ResourceAmount(ResourceType type, int amount)
    {
        Amount = amount;
        Type = type;
    }
}