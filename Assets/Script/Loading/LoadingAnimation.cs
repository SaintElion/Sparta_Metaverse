using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoadingAnimation : MonoBehaviour
{
    private Animator animator;
    private AnimationClip[] clips; //애니메이션 클립 넣을 배열

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Start()
    {
        clips = animator.runtimeAnimatorController.animationClips; //애니메이터 안의 모든 애니메이션 클립을 가져옴
        AnimationChoice();
    }
    public void AnimationChoice()
    {
        int random = Random.Range(0, clips.Length); // 랜덤 애니메이션 클립
        string name = clips[random].name;

        animator.Play(name);
    }
}
