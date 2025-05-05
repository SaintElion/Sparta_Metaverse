using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FlapBirdUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private GameObject UIPanel;

    private void Start()
    {
        if (UIPanel == null || scoreText == null || bestScoreText == null)
        {
            Debug.Log("UI component(s) of MiniGame Canvas is Null");
        }

        bestScoreText.gameObject.SetActive(false);
        UIPanel.gameObject.SetActive(false);
    }
    public void GameOverView()
    {
        bestScoreText.gameObject.SetActive(true);
        UIPanel.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }
}
