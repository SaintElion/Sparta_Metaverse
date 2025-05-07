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

    protected float runSpeed = 0f;

    private Camera cam;

    protected virtual void Awake()
    {
        rigidbodi = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();

        ComponentChecker.ComponentCheck(rigidbodi, this);
    }

    protected virtual void Start()
    {
        cam = Camera.main;  //메인 카메라를 찾아줌
                            //전역 초기화하지 않는 이유 = 런타임 중에 카메라를 찾아주기 때문에 Start()에서 초기화하는 게 좋음
    }

    protected virtual void DefaultMove() // 캐릭터 추가할 경우 공통사항 추가 및 상속
    {
        float upDown = Input.GetAxisRaw("UPDOWN");
        float rightLeft = Input.GetAxisRaw("RIGHTLEFT");

        // 두 방향키의 조합을 단위벡터로 생성
        // 단위벡터로 만드는 이유 : 1,0,-1로 이동하지만 대각선(1,1)에서 크기 1.414 -> 대각선에서 속도 빨라짐. 단위벡터로 모든 방향에서 같은 속도를 만들어준다
        moveDirection = new Vector2(upDown, rightLeft).normalized;
        
        if (Input.GetKey(KeyCode.LeftShift)) moveDirection *= runSpeed; 

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = cam.ScreenToWorldPoint(mousePosition); // camera.ScreenToWorldPoint(mousePosition) : 마우스 위치를 실제 게임 좌표로 변환해서 카메라에 넣음
        lookDirection = (worldPosition - (Vector2)transform.position);

        // 마우스 위치와 캐릭터 위치의 거리에 따라 lookDirection on/off
        if (lookDirection.magnitude < 1.0f) lookDirection = Vector2.zero; //magnitude : 벡터 크기만 뽑아줌
        else lookDirection = lookDirection.normalized;
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
