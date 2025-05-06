using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            DontDestroyOnLoad(gameObject); //씬이 여러개면 DontDestroy로 싱글톤 유지
        }
        else Destroy(gameObject);
    }

    //-----------------------------------------------------------------------------------------------------------

    private int money;
    public int Money { get => money; set => money = value; }

    private string sceneName;
    public string SceneName { get => sceneName; }

    public void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        UIManager.Instance.MoneyView(Money);
    }

    public void ChangeScene(string name)
    {
        //Debug.Log($"{name}으로 씬 변경");
        sceneName = name;
        SceneManager.LoadScene("Loading");
    }
    
    public void Moneies(int moneies)
    {
        Debug.Log(Money);
        Money += moneies;
        UIManager.Instance.MoneyView(Money);
    }
}

