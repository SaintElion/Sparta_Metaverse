// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.UI;

// public class NPCText : MonoBehaviour
// {
//     public Transform target;
//     private Text text;
//     private RectTransform balloon;

//     private void Awake()
//     {
//         target = transform.parent;
//         ComponentChecker.ComponentCheck(target, this);

//         text = GetComponentInChildren<Text>();
//         ComponentChecker.ComponentCheck(text, this);

//         balloon = GetComponentInChildren<RectTransform>();
//         ComponentChecker.ComponentCheck(balloon, this);
//     }
//     private void Start()
//     {
//         balloon.gameObject.SetActive(false);
//     }

//     private void Update()
//     {
//         Vector3 textPosition = Camera.main.WorldToScreenPoint(target.position + new Vector3(0f, 10f, 0f));
//         balloon.position = textPosition;
//     }

//     public void TextFailure()
//     {
//         balloon.gameObject.SetActive(true);
//         StartCoroutine(TextTypingMaker(text, balloon, "꽝", 0.2f)); //StartCorountine 안넣어주면 작동 안함
//     }

//     public void TextSuccess()
//     {
//         balloon.gameObject.SetActive(true);
//         StartCoroutine(TextTypingMaker(text, balloon, "당첨", 0.2f));
//     }

//     public IEnumerator TextTypingMaker(Text name, RectTransform balloon, string coment, float time) // 텍스트 이름, 텍스트 말풍선, 텍스트 내용, 지연시간 (이름이랑 말풍선은 혹시 몰라서 넣어놓음, 쓸모 없으면 지워도 됨)
//     {
//         Vector3 textPosition = Camera.main.WorldToScreenPoint(target.position + new Vector3(0f, 5f, 0f));
//         name.text = "";

//         for (int i = 0; i < coment.Length; i++)
//         {
//             name.text += coment[i];
//             yield return new WaitForSeconds(time);
//         }
//         yield return new WaitForSeconds(5f);

//         balloon.gameObject.SetActive(false);
//     }
// }
