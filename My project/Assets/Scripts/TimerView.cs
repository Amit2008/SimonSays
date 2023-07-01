using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Represents the view component for displaying the timer.
/// </summary>
public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText; // Reference to the timer text UI element.

    /// <summary>
    /// Updates the timer text to display the current time in minutes and seconds format.
    /// </summary>
    /// <param name="currentTime">The current time remaining.</param>
    public void UpdateTimeText(float currentTime)
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

