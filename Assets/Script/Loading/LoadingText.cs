using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    TextMeshProUGUI loadingText;
    LoadingText[] word;

    void Start()
    {
        StartCoroutine(LoadingTxt());
        word = GetComponent<LoadingText>();
    }

    IEnumerator LoadingTxt()
    {
        while (true)
        {
            foreach{}
        }

    }
}
