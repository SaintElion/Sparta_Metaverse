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

    public static bool ComponentCheck(Animator animator, MonoBehaviour owner)
    {
        if (animator == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an Animator");
            return false;
        }
        else return true;
    }

    public static bool ComponentCheck(TextMeshProUGUI textMeshProUGUI, MonoBehaviour owner)
    {
        if (textMeshProUGUI == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an Text");
            return false;
        }
        else return true;
    }

    public static bool ComponentCheck(Rigidbody2D rigidbodi, MonoBehaviour owner)
    {
        if (rigidbodi == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an RigidBody2D");
            return false;
        }
        else return true;
    }

    public static bool ComponentCheck(GameObject gameObject, MonoBehaviour owner)
    {
        if (gameObject == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an GameObject");
            return false;
        }
        else return true;
    }

    public static bool ComponentCheck(SpriteRenderer spriteRenderer, MonoBehaviour owner)
    {
        if (spriteRenderer == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an SpriteRenderer");
            return false;
        }
        else return true;
    }

    public static bool ComponentCheck(Transform transForm, MonoBehaviour owner)
    {
        if (transForm == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an Transform");
            return false;
        }
        else return true;
    }
    public static bool ComponentCheck(Text text, MonoBehaviour owner)
    {
        if (text == null)
        {
            Debug.Log($"{owner.GetType().Name} does not have an Transform");
            return false;
        }
        else return true;
    }
}


//----------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------