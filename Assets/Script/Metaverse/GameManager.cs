using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;
    public static GameManager Instance { get => gameManager; }

    private int currentScore = 0;

    UIManager uiManager;
    public UIManager UIManager { get => uiManager;}

    private void Awake()
    {
        gameManager = this; //게임매니저가 Awake에서 초기화되므로 싱글톤을 사용할 땐 Start()에서

        //GetComponent = 같은 오브젝트에 있는 컴포넌트를 찾아줌
        //FindObjectOfType = 씬 안에 존재하는 <T> 타입의 컴포넌트를 찾아줌
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
    }

    public void ChangeScene(string name)
    {
        //Debug.Log($"{name}으로 씬 변경");
        SceneManager.LoadScene(name);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 켜져있는 씬을 다시 가져옴
    }

    public void AddScoreFlapBird(int score)
    {
        currentScore += score;
        //Debug.Log($"Score = {currentScore}");
        uiManager.UpdateScore(currentScore);
    }

    public void gameOver()
    {
        uiManager.SetRestart();
    }
}

