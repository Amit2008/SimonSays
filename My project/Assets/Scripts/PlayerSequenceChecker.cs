using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checks the player's sequence against the latest sequence and invokes events based on the result.
/// </summary>
public class PlayerSequenceChecker : MonoBehaviour
{
    private List<ButtonType> latestSequence;
    private int currentSequenceIndex = 0;

    private void OnEnable()
    {
        GameplayEvents.Instance.NewStepMade += SaveLatestSequence;
        GameplayEvents.Instance.ButtonPressed += CheckPlayerSequence;
    }

    private void OnDisable()
    {
        GameplayEvents.Instance.NewStepMade -= SaveLatestSequence;
        GameplayEvents.Instance.ButtonPressed -= CheckPlayerSequence;
    }

    /// <summary>
    /// Saves the latest sequence and resets the current sequence index.
    /// </summary>
    /// <param name="latestSequence">The latest sequence of buttons.</param>
    private void SaveLatestSequence(List<ButtonType> latestSequence)
    {
        if (latestSequence == null || latestSequence.Count == 0)
        {
            Debug.LogError("SaveLatestSequence: latestSequence is null or empty - error");
            return;
        }

        this.latestSequence = latestSequence;
        currentSequenceIndex = 0;
    }

    /// <summary>
    /// Checks the player's button press against the expected button in the sequence.
    /// Invokes events based on the result.
    /// </summary>
    /// <param name="buttonModel">The button model representing the player's button press.</param>
    private void CheckPlayerSequence(ButtonModel buttonModel)
    {
        if (GameplayHelper.IsAutoPlay)
            return;

        ButtonType buttonType = buttonModel.ButtonType;
        if (latestSequence[currentSequenceIndex] != buttonType)
        {
            GameplayEvents.Instance.PlayerMadeBadSequence?.Invoke();
            return;
        }

        currentSequenceIndex++;

        if (currentSequenceIndex == latestSequence.Count)
        {
            GameplayEvents.Instance.PlayerFinishedSequenceSuccessfully?.Invoke();
        }
    }
}

