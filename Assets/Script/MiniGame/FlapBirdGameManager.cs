using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlapBirdGameManager : MonoBehaviour
{
    FlapBirdUIManager flapBirdUIManager;
    private int currentScore = 0;

    private void Start()
    {
        flapBirdUIManager = FindObjectOfType<FlapBirdUIManager>();
        flapBirdUIManager.UpdateScore(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //현재 켜져있는 씬을 다시 가져옴
    }

    public void AddScoreFlapBird(int score)
    {
        currentScore += score;
        //Debug.Log($"Score = {currentScore}");
        flapBirdUIManager.UpdateScore(currentScore);
    }

    public void gameOver()
    {
        flapBirdUIManager.SetRestart();
    }

    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
