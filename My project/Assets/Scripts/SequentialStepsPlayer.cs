﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialStepsPlayer : MonoBehaviour 
{
    [SerializeField] private float delayBetweenPlays;
    [SerializeField] private float microDelay = 0.1f; // added in case of the same button is pressed twice in a row
    private bool repeatMode = true;
    private void OnEnable()
    {
        GameplayEvents.Instance.NewStepMade += PlaySteps;
    }
    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.NewStepMade -= PlaySteps;
    }

    public void SetStepsPlayer(bool repeatMode, float gameSpeedModifier) 
    {
        this.repeatMode = repeatMode;
        delayBetweenPlays = delayBetweenPlays - ((delayBetweenPlays * gameSpeedModifier) - delayBetweenPlays);
    }

    private void PlaySteps(List<ButtonType> steps)
    {
        StartCoroutine(PlayStepsCoroutine(steps));
    }

    private IEnumerator PlayStepsCoroutine(List<ButtonType> steps)
    {
        GameplayHelper.isAutoPlay = true;
        yield return new WaitForSeconds(delayBetweenPlays);
        Debug.Log("PlayStepsCoroutine: Auto play sequence started!");
        GameplayEvents.Instance.SystemStartPlayingSteps?.Invoke();
        if (repeatMode)
        {
            foreach (var step in steps)
            {
                GameplayEvents.Instance.SystemPlayedStep?.Invoke(step, delayBetweenPlays);
                yield return new WaitForSeconds(delayBetweenPlays + microDelay);
            }
        }
        else 
        {
            GameplayEvents.Instance.SystemPlayedStep?.Invoke(steps[steps.Count - 1], delayBetweenPlays);
        }

        Debug.Log("PlayStepsCoroutine: Auto play sequence ended");
        GameplayEvents.Instance.SystemPlayedAllSteps?.Invoke();
        GameplayHelper.isAutoPlay = false;
    }
}
