﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static partial class Utils
{
    public static T GetAdd<T>(this GameObject go) where T : MonoBehaviour
    {
        var component = go.GetComponent<T>() ?? go.AddComponent<T>();
        return component;
    }

    public static IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType)
    {
        return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
    }

    public static GameObject GetChildGoByName(GameObject go, string nameToFind, int levelsDeep = 3)
    {
        GameObject result = null;

        var goListToProcess = new List<GameObject> { go };
        var goListProcessed = new List<GameObject>();
        var newGoListToProcessNextIt = new List<GameObject>();

        for(var i = 0; i < levelsDeep; i++)
        {
            foreach (var goToProcess in goListToProcess)
            {
                if(goListProcessed.Any(x => x == goToProcess))
                {
                    continue;
                }

                var childInGo = GetDirectChildGoByName(goToProcess, nameToFind);
                if(childInGo != null)
                {
                    return childInGo;
                }

                goListProcessed.Add(goToProcess);
                var childrenOfGo = GetChildrenGos(goToProcess);
                newGoListToProcessNextIt.AddRange(childrenOfGo);
            }

            goListToProcess = newGoListToProcessNextIt.ToList();
            newGoListToProcessNextIt.Clear();
        }


        return result;

    }

    public static GameObject GetDirectChildGoByName(GameObject go, string nameToFind)
    {
        var found = false;
        GameObject result = null;

        var currentTransform = go.transform;

        for (var i = 0; i < currentTransform.childCount && !found; i++)
        {
            var childGo = currentTransform.GetChild(i).gameObject;
            if(childGo.name == nameToFind)
            {
                result = childGo;
                found = true;
            }
        }

        return result;
    }

    public static List<GameObject> GetChildrenGos(GameObject go)
    {
        var result = new List<GameObject>();

        for (var i = 0; i < go.transform.childCount; i++)
        {
            var childGo = go.transform.GetChild(i).gameObject;
            result.Add(childGo);
        }

        return result;
    }

    public static GameObject GetStructuresGo(this Hex hex) => Utils.GetChildGoByName(hex.gameObject, "Props");
    public static GameObject GetMainGo(this Hex hex) => Utils.GetChildGoByName(hex.gameObject, "Main");

}