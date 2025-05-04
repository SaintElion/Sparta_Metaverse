using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    [Range(1.5f, 5f)] [SerializeField] private float runSpeed = 1.5f;
    private Camera cam;
    protected override void Start() //상속받는 메서드에서도 protected 써줄 것
    {
        cam = Camera.main; //메인 카메라를 찾아줌
                              //전역 초기화하지 않는 이유 = 런타임 중에 카메라를 찾아주기 때문에 Start()에서 초기화하는 게 좋음
    }

    protected override void DefaultMove()
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

}
