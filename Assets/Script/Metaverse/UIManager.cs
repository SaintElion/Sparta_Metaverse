using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public Button lobbyButton;


    void Start()
    {
        if
        (
            restartText == null ||
            scoreText == null ||
            lobbyButton == null
        )   Debug.Log("UI component(s) of MiniGame Canvas is Null");

        restartText.gameObject.SetActive(false);
        lobbyButton.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        lobbyButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

}

