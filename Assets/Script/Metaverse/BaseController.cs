using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class BaseController : MonoBehaviour
{
    //BaseController에서 캐릭터 전반에 대한 기본 설정 후
    //PlayerController에 상속해서 동작 담당

    //override는 재구현을 위해서 하는 거임. 기본적으로 부모 클래스도 함께 실행됨
    //virtual : 자식 클래스가 이걸 가져가서 재구성할 수 있게 하겠다

    protected Rigidbody2D rigidbodi;
    protected AnimationHandler animationHandler;

    [SerializeField] private SpriteRenderer spriteRenderer; //외부에서 설정값을 바꾸지 못하게 하면서 인스펙터 상에서 확인, 수정하고 싶을 떄 serialize + private

    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    protected virtual void Awake()
    {
        rigidbodi = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();

        ComponentChecker.ComponentCheck(rigidbodi, this);
    }

    protected virtual void Start()
    {
    }

    protected virtual void DefaultMove() // 모든 캐릭터 기본 이동 로직
    {
    }

    protected virtual void Update()
    {
        DefaultMove();
        Rotate(lookDirection);
    }
    protected virtual void FixedUpdate()
    {
        Movement(moveDirection);
    }

    private void Movement(Vector2 move)
    {
        move = move * 5; //이동속도 설정
        rigidbodi.velocity = move; //Rigidbody.velocity : 입력된 벡터에 따라 움직임을 부여함.

        //Vector2 direction = new Vector2(1, 0).normalized; // 방향(단위벡터)
        //Vector2 vector = direction * 5f;                // 초당 5를 이동하는 벡터(방향 + 크기)

        //rigidbody.velocity = vector; // velocity = 위치 벡터에 단위시간을 나눠서 위치 변화를 나타내줌 (Fixedupdate에서 실행해야 함)

        animationHandler.MoveAni(move);
    }

    private void Rotate(Vector2 look)
    {
        //float rotZ = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        //bool isLeft = Mathf.Abs(rotZ) > 90f;

        bool isLeft = look.x < 0f;

        spriteRenderer.flipX = isLeft;
    }

}
