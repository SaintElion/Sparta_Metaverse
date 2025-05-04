using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;

    public void Start()
    {
        Obstacles[] obstacles = GameObject.FindObjectsOfType<Obstacles>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MiniGame_Enviro"))
        {
            //Debug.Log("배경에 닿음");
            float whidthOfBgObj = ((BoxCollider2D)collision).size.x; //부딪힌 물체의 크기를 구하려면 콜라이더 형태를 명시해줘야 함
            Vector3 pos = collision.transform.position;

            pos.x += whidthOfBgObj * numBgCount;
            collision.transform.position = pos;
            return; // 백그라운드만 불러오는 상황에는 아래 메서드가 실행되지 않게 막아주기
        }

        Obstacles obstacles = collision.GetComponent<Obstacles>();
        if (obstacles)
        {
            obstacleLastPosition = obstacles.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }

    }
}
