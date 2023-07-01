using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents the view for the end game screen.
/// </summary>
public class EndGameView : MonoBehaviour
{
    /// <summary>
    /// Event triggered when the "Back to Main Menu" button is clicked.
    /// </summary>
    public Action BackToMainMenuClicked;

    [SerializeField] private GameObject popupObj;             // The popup object for the end game screen.
    [SerializeField] private TextMeshProUGUI titleText;       // The text displaying the title.
    [SerializeField] private TextMeshProUGUI scoreText;       // The text displaying the player's score.
    [SerializeField] private Button goToMainMenu;             // The button to go back to the main menu.

    /// <summary>
    /// Sets up the end game view with the provided score and player's win status.
    /// </summary>
    /// <param name="score">The player's score.</param>
    /// <param name="playerWon">True if the player won the game, false otherwise.</param>
    public void SetEndGameView(int score, bool playerWon)
    {
        popupObj.SetActive(true);
        titleText.text = playerWon ? GameConstants.PlayerWonText : GameConstants.PlayerLostText;
        scoreText.text = GameConstants.ScoreText + score.ToString();
    }

    /// <summary>
    /// Handles the click event of the "Back to Main Menu" button.
    /// </summary>
    public void OnBackToMainMenuClick()
    {
        BackToMainMenuClicked?.Invoke();
    }

    /// <summary>
    /// Sets the interaction state of the "Main Menu" button.
    /// </summary>
    /// <param name="state">The desired interaction state.</param>
    public void SetMainMenuButtonInteractionState(bool state)
    {
        goToMainMenu.interactable = state;
    }
}
