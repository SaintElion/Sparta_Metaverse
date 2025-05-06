using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    //readonly = 결과값을 한 번 계산해서 저장해두고 앞으로 따로 계산할 필요 없이 바로 사용할 수 있게 해줌 -> 최적화
    //StringToHash = 문자열을 고유한 해시값(int)으로 바꿈. 해시값 딱 한 번 바꾸고 readonly로 저장해서 빠른 검색을 할 수 있게 만듦

    private static readonly int isMoving = Animator.StringToHash("isMoving");
    private static readonly int isCollision = Animator.StringToHash("isCollision");
    public Animator animator;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>(); //player 오브젝트에 넣을 스크립트이기 때문에 하위 오브젝트 검색해줘야 함 
        ComponentChecker.ComponentCheck(animator, this);
    }

    public void MoveAni(Vector2 move)
    {
        animator.SetBool(isMoving, move.magnitude > 0.5f);
    }
    
    public void StopAni(Vector2 move)
    {
        animator.SetTrigger(isCollision);
    }
}
