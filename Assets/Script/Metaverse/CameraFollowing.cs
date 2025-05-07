using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private MainPlayer target;

    void Start()
    {
        target = FindObjectOfType<MainPlayer>();
        if (target == null) return;
    }

    void Update()
    {
        Vector2 targeting = target.transform.position;

        //카메라 Z축이 안맞춰져서 튕겨나감
        Vector3 CameraFollowing = new Vector3(targeting.x, targeting.y, -10);
        transform.position = CameraFollowing;
    }
}
