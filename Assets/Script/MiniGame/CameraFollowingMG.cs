using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CameraFollowingMG : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targeting = target.transform.position;
        Vector3 cameraFollowing = new Vector3(targeting.x, 0, -10);
        transform.position = cameraFollowing;
    }
}
