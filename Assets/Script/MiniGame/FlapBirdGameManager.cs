using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
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
        ComponentChecker.ComponentCheck(flapBirdUIManager, this);
        flapBirdUIManager.UpdateScore(0);
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
        GameManager.Instance.Money += 100;
    }
    public void ScoreDelete()
    {
        PlayerPrefs.DeleteKey("BestScoreRecord");
        flapBirdUIManager.UpdateBestScore(0);
    }

    public void GameStart()
    {
        flapBirdUIManager.StartPanelClose(); 
        Time.timeScale = 1f;
    }

    public void gameOver()
    {
        isDead = true;
        int scoreRecord = PlayerPrefs.GetInt("BestScoreRecord");

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
        GameManager.Instance.GoingStage("Lobby");
    }


}
