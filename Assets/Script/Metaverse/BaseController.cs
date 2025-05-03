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

    //상속은 재구현을 위해서 하는 거임. 상속하지 않으면 부모 클래스 멤버가 실행되는 거임
    //virtual : 자식 클래스가 이걸 가져가서 재구성할 수 있게 하겠다 (기본적으로 실행은 됨)
    //protected : 부모, 자식 클래스 내에서만 접근하고 싶을 때

    protected Rigidbody2D rigidbodi;

    [SerializeField] private SpriteRenderer spriteRenderer;

    protected Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    protected virtual void Awake()
    {
        rigidbodi = GetComponent<Rigidbody2D>();
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
    }

    private void Rotate(Vector2 look)
    {
        // 0.0 ~ y.x를 라디안으로 반환해주고 다시 디그리로 변경 후 절대값을 90과 비교해서
        // 캐릭터 방향전환 + 무기 회전을 동시에

        float rotZ = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        spriteRenderer.flipX = isLeft;
    }
}
