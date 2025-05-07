using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static UIManager uiManager;
    public static UIManager Instance { get => uiManager; }

    private void Awake()
    {
        if (Instance == null)
        {
            uiManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    //-----------------------------------------------------------------------------------------------------------

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI shiftToRun;
    public void MoneyView(int Money)
    {
        moneyText.text = Money.ToString();
    }
    public void HideUI()
    {
        shiftToRun.gameObject.SetActive(false);
    }

    public void ShowUI()
    {
        shiftToRun.gameObject.SetActive(true);
        ComponentChecker.ComponentCheck(shiftToRun, this);
    }
}

