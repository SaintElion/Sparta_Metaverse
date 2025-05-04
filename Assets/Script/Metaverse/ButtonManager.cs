using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private SceneChangeBttn[] btns;

    private static ButtonManager instance;
    public static ButtonManager Instance { get => instance; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        //Debug.Log($"{name}으로 씬 변경 완료");


    }

    //상점,던전 추가
    //로딩 애니메이션 추가
}
