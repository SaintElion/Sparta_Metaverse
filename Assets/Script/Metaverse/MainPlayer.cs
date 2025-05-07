using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPlayer : MonoBehaviour
{
    public static MainPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded; //이벤트 등록, 함수 실행
    }

    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------

    private Vector2 moveDirection = Vector2.zero;
    public Vector2 MoveDirection { get => moveDirection; }

    private Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get => lookDirection; }

    [SerializeField] private float runSpeed = 1.5f; //외부에서 설정값을 바꾸지 못하게 하면서 인스펙터 상에서 확인, 수정하고 싶을 떄 serialize + private

    public Transform player;
    private AnimationHandler animationHandler;
    private Rigidbody2D rigidbodi;
    private SpriteRenderer spriteRenderer;
    private Camera cam;

    private void Start()
    {
        rigidbodi = GetComponent<Rigidbody2D>();
        ComponentChecker.ComponentCheck(rigidbodi, this);

        animationHandler = GetComponent<AnimationHandler>();
        ComponentChecker.ComponentCheck(animationHandler, this);

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ComponentChecker.ComponentCheck(spriteRenderer, this);

        transform.position = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        if (cam == null) return;
        DefaultMove();
        Rotate(lookDirection);
    }
    private void FixedUpdate()
    {
        Movement(moveDirection);
    }

    private void DefaultMove() // 캐릭터 추가할 경우 공통사항 추가 및 상속
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

    private void Movement(Vector2 move)
    {
        move = move * 5; //이동속도 설정
        rigidbodi.velocity = move; //Rigidbody.velocity : 입력된 벡터에 따라 움직임을 부여함.

        //Vector2 direction = new Vector2(1, 0).normalized; // 방향(단위벡터)
        //Vector2 vector = direction * 5f;                // 초당 5를 이동하는 벡터(방향 + 크기)

        //rigidbody.velocity = vector; // velocity = 위치 벡터에 단위시간을 나눠서 위치 변화를 나타내줌 (물리연산이니까 Fixedupdate에서)

        animationHandler.MoveAni(move);
    }

    private void Rotate(Vector2 look)
    {
        //float rotZ = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        //bool isLeft = Mathf.Abs(rotZ) > 90f;

        bool isLeft = look.x < 0f;

        spriteRenderer.flipX = isLeft;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) //이벤트
    {
        switch (scene.name)
        {
            case "FlapBird":
                HideCharacter();
                return;

            case "Loading":
                HideCharacter();
                break;
                
            default:
                ShowCharacter();
                cam = Camera.main;
                transform.position = Vector3.zero; //시작 위치 0으로 고정
                return;
        }
    }

    private void OnDestroy() //씬이나 오브젝트가 파괴될 때 자동으로 실행하는 함수
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; //이벤트 종료
    }

    public void HideCharacter() //미니게임, 로딩씬에서 캐릭터 잠시 비활성화
    {
        player.gameObject.SetActive(false);
    }

    public void ShowCharacter()
    {
        player.gameObject.SetActive(true);
    }
}
