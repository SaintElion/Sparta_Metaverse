using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeBttn : ButtonManager
{
    // 버튼 사진 2장 필요함, Sprite
    [SerializeField] private Sprite bttnUp;
    [SerializeField] private Sprite bttnDown;

    private SpriteRenderer spriteRenderer;

    //Awake = 컴포넌트 초기화할 때
    //Start = 다른 컴포넌트와 연결하거나 제어할 때
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) PressBttn();
    }

    void PressBttn()
    {
        //Debug.Log("버튼 작동");

        BttnDown();
        //씬 변경
    }

    public void BttnUp()
    {
        spriteRenderer.sprite = bttnUp;
    }

    public void BttnDown()
    {
        spriteRenderer.sprite = bttnDown;
    }
}
