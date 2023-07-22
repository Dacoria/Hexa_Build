public enum HexSelectCategoryType
{
    StateChange,
    GainRsc,
}

public static class HexSelectCategoryTypeExt
{
    public static bool IsCategoryAvailable(this HexSelectCategoryType category, HexStateType state)
    {
        switch(category)
        {
            case HexSelectCategoryType.StateChange:
                return true;
            case HexSelectCategoryType.GainRsc:
                return state.Props().HasRscGains();
            default:
                throw new System.Exception("");
        }
    }
}