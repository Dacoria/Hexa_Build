public enum HexSelectCategoryType
{
    StateChange,
    GainRsc,
    Expand
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
            case HexSelectCategoryType.Expand:
                return ResourceHandler.instance.HasResourcesToSpendInStock(HexExpansion.ExpansionCost()) &&
                    HexGrid.instance.GetFreePlacesDirectlyAroundHex(hex.HexCoordinates).Count > 0;
            default:
                throw new System.Exception("");
        }
    }
}