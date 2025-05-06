using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    private TextMeshProUGUI loadingText;

    private void Start()
    {
        loadingText = GetComponent<TextMeshProUGUI>();
        string text = loadingText.text;
        StartCoroutine(LoadingTxt(text));
    }

    IEnumerator LoadingTxt(string text)
    {
        while (true)
        {
            loadingText.text = "";
            for (int i = 0; i < text.Length; i++) //로딩텍스트 타이핑
            {
                loadingText.text += text[i]; //+=는 상수 뿐만 아니라 텍스트에도 사용할 수 있다
                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i <= text.Length; i++) //로딩텍스트 천천히 지워지게
            {
                loadingText.text = text.Substring(0, i);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
