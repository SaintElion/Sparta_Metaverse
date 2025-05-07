using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//----------------------------------------------------------------------------------------------
//------------------------------------ComponentChecker------------------------------------------
//----------------------------------------------------------------------------------------------
public static class ComponentChecker
{
    //제네릭으로 바꾸기

    public static bool ComponentCheck<T>(T component, MonoBehaviour monoBehaviour) where T : UnityEngine.Object
    {
        if (component == null)
        {
            Debug.Log($"{monoBehaviour.name}does not have an {component}");
            return false;
        }
        else return true;
    }
}


//----------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------