using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EndGameView))]
public class EndGameController : MonoBehaviour
{
    [SerializeField] ScoreIncrementorController scoreIncrementor;
    private EndGameView endGameview;
    private HighScoreSaver highScoreSaver;
    private void Awake()
    {
        endGameview = GetComponent<EndGameView>();
        highScoreSaver = new HighScoreSaver(scoreIncrementor);
    }

    private void OnEnable()
    {
        endGameview.BackToMainMenuClicked += GoToMainMenu;
        GameplayEvents.Instance.TimeFinished += HandleGameWon;
        GameplayEvents.Instance.PlayerMadeBadSequence += HandleLevelLost;
    }
    private void OnDisable()
    {
        if (GameplayEvents.Instance == null || endGameview == null) return;

        endGameview.BackToMainMenuClicked -= GoToMainMenu;
        GameplayEvents.Instance.TimeFinished -= HandleGameWon;
        GameplayEvents.Instance.PlayerMadeBadSequence -= HandleLevelLost;
    }

    private void HandleGameWon()
    {
        SetGameEndView(true);
        highScoreSaver.SaveHighScore();
    }

    private void HandleLevelLost()
    {
        SetGameEndView(false);
    }

    private void SetGameEndView(bool playerWon)
    {
        int score = scoreIncrementor.Score;
        endGameview.SetEndGameView(score, playerWon);
    }

    private void GoToMainMenu() 
    {
        endGameview.SetMainMenuButtonInteractionState(false);
        GameplayEvents.Instance.GoToMainMenu?.Invoke();
    }
}