using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FlapBirdGameManager : MonoBehaviour
{
    FlapBirdUIManager flapBirdUIManager;
    private int currentScore = 0;
    public bool isDead = false;
    public bool isGameStart = false;
    public float time = 0;

    private void Awake()
    {
        Time.timeScale = 0f; // Start()에 넣으면 0.1초 정도 실행되다가 멈춤
    }
    private void Start()
    {
        flapBirdUIManager = FindObjectOfType<FlapBirdUIManager>();
        flapBirdUIManager.UpdateScore(0);
        flapBirdUIManager.UpdateBestScore(0);
    }

    // private void Update()
    // {
    //     time += Time.deltaTime; 실시간 + 최고 시간 표시
    // }

    public void AddScoreFlapBird(int score)
    {
        currentScore += score;
        //Debug.Log($"Score = {currentScore}");
        flapBirdUIManager.UpdateScore(currentScore);
    }

    public void Update()
    {
        if (!isGameStart && Input.anyKeyDown)
        {
            isGameStart = true;
            GameStart();
        }
    }

    public void GameStart()
    {
        flapBirdUIManager.StartPanel(); //추후 수정 필요 (GameManager에서 UIManager를 호출함)
        Time.timeScale = 1f;
    }

    public void gameOver()
    {
        isDead = true;
        int scoreRecord = PlayerPrefs.GetInt("BestScoreRecord"); //최고점수 불러오기

        if (currentScore > scoreRecord)
        {
            PlayerPrefs.SetInt("BestScoreRecord", currentScore);
            PlayerPrefs.Save();

            flapBirdUIManager.UpdateBestScore(currentScore);
        }
        else
        {
            flapBirdUIManager.UpdateBestScore(scoreRecord);
        }

        flapBirdUIManager.GameOverView();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 켜져있는 씬을 다시 가져옴
    }

    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby"); //로비로 이동
    }
}
