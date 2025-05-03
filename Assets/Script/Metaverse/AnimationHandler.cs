using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int isMoving = Animator.StringToHash("isMoving");
    public Animator animator;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>(); //player 오브젝트에 넣을 스크립트이기 때문에 하위 오브젝트 검색해줘야 함 
    }

    public void MoveAni(Vector2 move)
    {
        animator.SetBool(isMoving, move.magnitude > 0.5f);
    }
}
