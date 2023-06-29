using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSequenceChecker : MonoBehaviour
{
    private List<ButtonType> latestSequence;
    int currentSequenceIndex = 0;

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

    private void CheckPlayerSequence(ButtonModel buttonModel) 
    {
        if (GameplayHelper.isAutoPlay) return;

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
