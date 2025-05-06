using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    NPCAnimation npcAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float random = Random.Range(0.1f, 1.0f);
        npcAnimation.EventAnim();
        if (random > 0.5f) EventSuccess();
        else EventFailure();
    }

    private void EventSuccess()
    {
        GameManager.Instance.Money += 10000;
    }

    private void EventFailure()
    {

    }
}
