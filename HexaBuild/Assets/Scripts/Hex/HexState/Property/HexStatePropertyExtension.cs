using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class HexStatePropertyExtension
{
    public static IHexStateProperty Props(this HexStateType type) => hexStatePropertiesMap.Single(x => x.Type == type);
    public static int HexGrowthLevel(this IHexStateProperty hexStateProperty)
    {
        var growthProp = hexStateProperty as IRscGrowthInState;
        if(growthProp == null)
        {
            return -1;
        }

        return growthProp.RscPerGrowthLevel.Min(x => x.Level);
    }

    private static List<IHexStateProperty> _hexStatePropertiesMap;
    private static List<IHexStateProperty> hexStatePropertiesMap
    {
        get
        {
            if (_hexStatePropertiesMap == null)
            {
                _hexStatePropertiesMap = CreateHexStatePropertiesMap();
            }
            return _hexStatePropertiesMap;
        }
    } 

    private static List<IHexStateProperty> CreateHexStatePropertiesMap()
    {
        var abilitiesList = new List<IHexStateProperty>();
        foreach (Type t in Utils.FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(IHexStateProperty)))
        {
            var instance = (IHexStateProperty)Activator.CreateInstance(t);
            abilitiesList.Add(instance);
        }

        return abilitiesList;
    }
}