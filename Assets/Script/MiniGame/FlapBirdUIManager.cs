using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FlapBirdUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI hideEndText;
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject startPanel;

    private void Start()
    {
        if (uiPanel == null || scoreText == null || bestScoreText == null)
        {
            Debug.Log("UI component(s) of MiniGame Canvas is Null");
        }

        bestScoreText.gameObject.SetActive(false);
        uiPanel.gameObject.SetActive(false);
        hideEndText.gameObject.SetActive(false);

        startPanel.gameObject.SetActive(true);
    }

    public void StartPanelClose()
    {
        startPanel.gameObject.SetActive(false);
    }

    public void GameOverView()
    {
        bestScoreText.gameObject.SetActive(true);
        uiPanel.gameObject.SetActive(true);
        StartCoroutine(HideEndText());
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }

    // public void UpdateTime()
    // {
        
    // }

    IEnumerator HideEndText() //Coroutine 사용하려면 IEnumrator 타입의 메서드를 통해야 함
    {
        yield return new WaitForSeconds(1.5f);
        hideEndText.gameObject.SetActive(true);
    }
}
