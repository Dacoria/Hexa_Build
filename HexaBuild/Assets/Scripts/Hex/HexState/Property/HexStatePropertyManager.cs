using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class HexStatePropertyManager
{
    public static IHexStateProperty GetProperties(this HexStateType type) => hexStatePropertiesMap.Single(x => x.Type == type);
       

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