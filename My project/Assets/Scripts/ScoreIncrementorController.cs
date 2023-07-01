using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the score incrementation and updates the associated score incrementor view.
/// </summary>
[RequireComponent(typeof(ScoreIncrementorView))]
public class ScoreIncrementorController : MonoBehaviour
{
    private int currentScore = 0;
    private int scorePerStep = 1;
    private ScoreIncrementorView scoreIncrementorView;

    /// <summary>
    /// Gets the current score.
    /// </summary>
    public int Score => currentScore;

    private void Awake()
    {
        scoreIncrementorView = GetComponent<ScoreIncrementorView>();
    }

    private void OnEnable()
    {
        GameplayEvents.Instance.PlayerFinishedSequenceSuccessfully += IncreaseScore;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.PlayerFinishedSequenceSuccessfully -= IncreaseScore;
    }

    /// <summary>
    /// Sets the score increment per step.
    /// </summary>
    /// <param name="scorePerStep">The score increment per step.</param>
    public void SetScorePerStep(int scorePerStep)
    {
        if (scorePerStep >= this.scorePerStep)
            this.scorePerStep = scorePerStep;
    }

    private void IncreaseScore()
    {
        currentScore += scorePerStep;
        scoreIncrementorView.SetScore(currentScore);
    }
}

