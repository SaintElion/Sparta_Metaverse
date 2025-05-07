using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraFollowingShop : MonoBehaviour
{
    private Transform target;

    private void Start()
    {
        Camera.main.GetComponent<CameraFollowingShop>().Target(MainPlayer.Instance.transform); //씬 시작되고 갱신된 캐릭터 트랜스폼 가져옴
    }

    private void Target(Transform t) // 캐릭터 트랜스폼을 변수에 저장
    {
        target = t;
    }

    private void Update()
    {
        Vector2 targeting = target.transform.position;

        Vector3 CameraFollowing = new Vector3(targeting.x, targeting.y, -10);  //Z축이 안맞추면 튕겨나감
        transform.position = CameraFollowing;
    }
}