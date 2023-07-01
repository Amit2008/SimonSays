using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the sequential playback of steps in the game.
/// </summary>
public class SequentialStepsPlayer : MonoBehaviour
{
    [SerializeField] private float delayBetweenPlays;
    [SerializeField] private float microDelay = 0.1f; // Added in case the same button is pressed twice in a row
    private bool repeatMode = true;

    /// <summary>
    /// Subscribes to relevant events when the object is enabled.
    /// </summary>
    private void OnEnable()
    {
        GameplayEvents.Instance.NewStepMade += PlaySteps;
        GameplayEvents.Instance.TimeFinished += StopSequence;
    }

    /// <summary>
    /// Unsubscribes from events when the object is disabled.
    /// </summary>
    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.NewStepMade -= PlaySteps;
        GameplayEvents.Instance.TimeFinished -= StopSequence;
    }

    /// <summary>
    /// Sets the configuration for the sequential steps player.
    /// </summary>
    /// <param name="repeatMode">Whether the sequence should be repeated.</param>
    /// <param name="gameSpeedModifier">The modifier for the game speed.</param>
    public void SetStepsPlayer(bool repeatMode, float gameSpeedModifier)
    {
        this.repeatMode = repeatMode;
        delayBetweenPlays = delayBetweenPlays - ((delayBetweenPlays * gameSpeedModifier) - delayBetweenPlays);
    }

    /// <summary>
    /// Starts playing the steps in sequence.
    /// </summary>
    /// <param name="steps">The list of steps to play.</param>
    private void PlaySteps(List<ButtonType> steps)
    {
        StartCoroutine(PlayStepsCoroutine(steps));
    }

    /// <summary>
    /// Stops the current sequence playback.
    /// </summary>
    private void StopSequence()
    {
        StopCoroutine(PlayStepsCoroutine(new List<ButtonType>()));
    }

    /// <summary>
    /// Coroutine that plays the steps in sequence.
    /// </summary>
    /// <param name="steps">The list of steps to play.</param>
    private IEnumerator PlayStepsCoroutine(List<ButtonType> steps)
    {
        GameplayHelper.IsAutoPlay = true;
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
        GameplayHelper.IsAutoPlay = false;
    }
}

