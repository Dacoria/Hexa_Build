public enum HexSelectCategoryType
{
    StateChange,
    GainRsc,
}

public static class HexSelectCategoryTypeExt
{
    public static bool IsCategoryAvailable(this HexSelectCategoryType category, Hex hex)
    {
        switch(category)
        {
            case HexSelectCategoryType.StateChange:
                return true;
            case HexSelectCategoryType.GainRsc:
                return hex.HexStateType.Props().HasRscGains() && hex.GetComponent<RscGainBehaviour>() != null;
            default:
                throw new System.Exception("");
        }
    }
}