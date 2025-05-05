using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    FlapBirdGameManager gameManager;
    public float highPositionY = 1f;
    public float lowPositionY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float spacePerMt = 4f;

    public void Start()
    {
        gameManager = FindObjectOfType<FlapBirdGameManager>();
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obestacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2.0f;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(spacePerMt, 0, 0);

        placePosition.y = Random.Range(lowPositionY, highPositionY);

        transform.position = placePosition;
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameManager.isDead == true) return;

        Player player = collision.GetComponent<Player>();

        if (player) gameManager.AddScoreFlapBird(1);
    }
}
