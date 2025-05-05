using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class FlapBirdGameManager : MonoBehaviour
{
    FlapBirdUIManager flapBirdUIManager;
    private int currentScore = 0;
    public bool isDead = false;

    private void Start()
    {
        flapBirdUIManager = FindObjectOfType<FlapBirdUIManager>();
        flapBirdUIManager.UpdateScore(0);
        flapBirdUIManager.UpdateBestScore(0);
    }

    public void AddScoreFlapBird(int score)
    {
        currentScore += score;
        //Debug.Log($"Score = {currentScore}");
        flapBirdUIManager.UpdateScore(currentScore);
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
