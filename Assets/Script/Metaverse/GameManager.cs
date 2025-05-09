using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //게임매니저가 Awake에서 초기화되므로 싱글톤을 사용할 땐 Start()에서
            DontDestroyOnLoad(gameObject); //씬이 여러개면 DontDestroy로 싱글톤 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------------------

    private int money;
    public int Money
    {
        get => money;
        set
        {
            money = value;
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.Save();
            UIManager.Instance.MoneyView(money);
        }
    }

    private string sceneName;
    public string SceneName { get => sceneName; }

    public void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        UIManager.Instance.MoneyView(money);
    }

    public void GoingStage(string name)
    {
        UIManager.Instance.HideUI();
        //Debug.Log($"{name}으로 씬 변경");
        sceneName = name;
        SceneManager.LoadScene("Loading");
    }

    public void GoingLobby()
    {
        SceneManager.LoadScene("Loading");
        UIManager.Instance.ShowUI();
    }
}

