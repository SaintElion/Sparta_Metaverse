using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    private static readonly int isTrigger = Animator.StringToHash("isTrigger");
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        ComponentChecker.ComponentCheck(animator, this);
    }

    public void EventAnim()
    {
        animator.SetTrigger(isTrigger);
    }


}
