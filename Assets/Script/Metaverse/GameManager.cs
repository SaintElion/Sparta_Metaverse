using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get => gameManager; }

    private void Awake()
    {
        if (Instance == null)
        {
            gameManager = this; //게임매니저가 Awake에서 초기화되므로 싱글톤을 사용할 땐 Start()에서
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void ChangeScene(string name)
    {
        //Debug.Log($"{name}으로 씬 변경");
        SceneManager.LoadScene(name);
    }
}

