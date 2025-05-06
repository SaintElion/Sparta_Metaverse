using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;

public class SceneChangeBttn : MonoBehaviour
{
    [SerializeField] private Sprite bttnUp;
    [SerializeField] private Sprite bttnDown;
    [SerializeField] private string sceneName;

    private SpriteRenderer spriteRenderer;

    //Awake = 컴포넌트 초기화할 때
    //Start = 다른 컴포넌트와 연결하거나 제어할 때
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) PressBttn();
    }

    private void PressBttn()
    {
        //Debug.Log("버튼 작동");

        BttnDown();
        SceneChange();
    }

    public void BttnUp()
    {
        spriteRenderer.sprite = bttnUp;
    }

    public void BttnDown()
    {
        spriteRenderer.sprite = bttnDown;
    }

    public void SceneChange()
    {
        GameManager.Instance.ChangeScene(sceneName); //버튼마다 이동할 Scene 지정해놓고 GameManager에서 변경
    }
}
