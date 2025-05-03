using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    protected override void Start() //상속받는 메서드에서도 protected 써줄 것
    {
        camera = Camera.main; //메인 카메라를 찾아줌
                              //전역 초기화하지 않는 이유 = 런타임 중에 카메라를 찾아주기 때문에
                              //Start() 시점이 돼야 제대로 초기화 가능
    }

    protected override void DefaultMove()
    {
        float upDown = Input.GetAxisRaw("UPDOWN");
        float rightLeft = Input.GetAxisRaw("RIGHTLEFT");

        // 두 방향키의 조합을 단위벡터로 생성
        // 단위벡터로 만드는 이유 : 어차피 1,0,-1에 따라 이동하지만 대각선 1,1에서 크기는 루트2가 됨 -> 대각선에서 속도 빨라짐. 단위벡터로 방향에 관계 없이 같은 속도를 만들어준다
        moveDirection = new Vector2(upDown, rightLeft).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = camera.ScreenToWorldPoint(mousePosition); // camera.ScreenToWorldPoint(mousePosition) : 마우스 위치를 실제 게임 좌표로 변환해서 카메라에 넣음
        lookDirection = (worldPosition - (Vector2)transform.position);

        // 마우스 위치와 캐릭터 위치의 거리에 따라 lookDirection on/off
        if (lookDirection.magnitude < 1.0f) lookDirection = Vector2.zero; //magnitude : 벡터 크기만 뽑아줌
        else lookDirection = lookDirection.normalized;
    }
}
