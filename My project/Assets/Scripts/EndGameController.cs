using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the controller for the end game screen.
/// </summary>
[RequireComponent(typeof(EndGameView))]
public class EndGameController : MonoBehaviour
{
    [SerializeField] private ScoreIncrementorController scoreIncrementor;   // Reference to the score incrementor controller.

    private EndGameView endGameView;              // Reference to the end game view component.
    private HighScoreSaver highScoreSaver;        // Instance of the high score saver.

    private void Awake()
    {
        endGameView = GetComponent<EndGameView>();
        highScoreSaver = new HighScoreSaver(scoreIncrementor);
    }

    private void OnEnable()
    {
        endGameView.BackToMainMenuClicked += GoToMainMenu;
        GameplayEvents.Instance.TimeFinished += HandleGameWon;
        GameplayEvents.Instance.PlayerMadeBadSequence += HandleLevelLost;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null || endGameView == null) return;

        endGameView.BackToMainMenuClicked -= GoToMainMenu;
        GameplayEvents.Instance.TimeFinished -= HandleGameWon;
        GameplayEvents.Instance.PlayerMadeBadSequence -= HandleLevelLost;
    }

    /// <summary>
    /// Handles the game won event.
    /// </summary>
    private void HandleGameWon()
    {
        SetGameEndView(true);
        highScoreSaver.SaveHighScore();
    }

    /// <summary>
    /// Handles the level lost event.
    /// </summary>
    private void HandleLevelLost()
    {
        SetGameEndView(false);
    }

    /// <summary>
    /// Sets up the end game view with the provided player's win status.
    /// </summary>
    /// <param name="playerWon">True if the player won the game, false otherwise.</param>
    private void SetGameEndView(bool playerWon)
    {
        int score = scoreIncrementor.Score;
        endGameView.SetEndGameView(score, playerWon);
    }

    /// <summary>
    /// Handles the "Back to Main Menu" button click event.
    /// </summary>
    private void GoToMainMenu()
    {
        endGameView.SetMainMenuButtonInteractionState(false);

        if (GeneralEvents.Instance != null)
            GeneralEvents.Instance.GoToMainMenu?.Invoke(gameObject.scene.name);
    }
}