using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{
    private Transform targetNPC;
    private Text text;
    private Image image;

    private void Awake()
    {
        targetNPC = GetComponentInParent<Transform>();
        ComponentChecker.ComponentCheck(targetNPC, this);
        text = GetComponentInChildren<Text>();
        ComponentChecker.ComponentCheck(text, this);
        image = GetComponentInChildren<Image>();
    }
    private void Start()
    {
        transform.position = targetNPC.transform.position + new Vector3(0, 6f, 0);
        image.gameObject.SetActive(false);
    }
    public void TextFailure()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(TextTypingMaker(text, image, "Null사랑해", 0.2f)); //StartCorountine 안넣어주면 작동 안함
    }

    void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public void TextSuccess()
    {
        image.gameObject.SetActive(true);
        StartCoroutine(TextTypingMaker(text, image, "입금완료", 0.2f));
    }

    public IEnumerator TextTypingMaker(Text name, Image balloon, string coment, float time) // 텍스트 이름, 텍스트 말풍선, 텍스트 내용, 지연시간 (이름이랑 말풍선은 혹시 몰라서 넣어놓음, 쓸모 없으면 지워도 됨)
    {
        name.text = "";

        for (int i = 0; i < coment.Length; i++)
        {
            name.text += coment[i];
            yield return new WaitForSeconds(time);
        }
        yield return new WaitForSeconds(5f);

        image.gameObject.SetActive(false);
    }
}
