using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    private NPCAnimation npcAnimation;
    // private NPCText npcText;

    private void Awake()
    {
        npcAnimation = GetComponentInChildren<NPCAnimation>();
        ComponentChecker.ComponentCheck(npcAnimation, this);

        // npcText = GetComponentInChildren<NPCText>();
        // ComponentChecker.ComponentCheck(npcText, this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float random = Random.Range(0.1f, 1.0f);
        npcAnimation.EventAnim();

        if (random > 0.3f) EventSuccess();
        else EventFailure();
    }

    private void EventSuccess()
    {
        // npcText.TextSuccess();
        GameManager.Instance.Money += 1000;
    }

    private void EventFailure()
    {
        // npcText.TextFailure();
        GameManager.Instance.Money = 0;
    }
}
