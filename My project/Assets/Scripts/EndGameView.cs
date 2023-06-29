using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGameView : MonoBehaviour
{
    public Action BackToMainMenuClicked;

    [SerializeField] private GameObject popupObj;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button goTomainMenu;

    public void SetEndGameView(int score, bool playerWon) 
    {
        popupObj.SetActive(true);
        titleText.text = playerWon ? GameConstants.PlayerWonText : GameConstants.PlayerLostText;
        scoreText.text = GameConstants.ScoreText + score.ToString();
    }

    public void OnBackToMainMenuClick() 
    {
        BackToMainMenuClicked?.Invoke();
    }

    public void SetMainMenuButtonInteractionState(bool state) 
    {
        goTomainMenu.interactable = state;
    }
}
