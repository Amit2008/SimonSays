using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreIncrementorView))]
public class ScoreIncrementorController : MonoBehaviour
{
    private int currentScore = 0;
    private int scorePerStep = 1;
    private ScoreIncrementorView scoreIncrementorView;

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
