using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the controller for the timer functionality.
/// </summary>
[RequireComponent(typeof(TimerView))]
public class TimerController : MonoBehaviour
{
    private TimerView timerView;    // Reference to the timer view component.
    private float levelTime;        // The total time for the level.
    private float currentTime = 0;  // The current time remaining.
    private bool startCounting = false; // Flag indicating whether the timer is counting down.

    private void Awake()
    {
        timerView = GetComponent<TimerView>();
    }

    private void OnEnable()
    {
        GameplayEvents.Instance.StartButtonClicked += StartTimer;
        GameplayEvents.Instance.PlayerMadeBadSequence += StopTimer;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.StartButtonClicked -= StartTimer;
        GameplayEvents.Instance.PlayerMadeBadSequence -= StopTimer;
    }

    private void Update()
    {
        if (currentTime > 0f && startCounting)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0f)
            {
                currentTime = 0f;
                StopTimer();
                GameplayEvents.Instance.TimeFinished?.Invoke();
            }

            timerView.UpdateTimeText(currentTime);
        }
    }

    /// <summary>
    /// Sets the initial timer value for the level.
    /// </summary>
    /// <param name="levelTime">The total time for the level.</param>
    public void SetTimer(float levelTime)
    {
        this.levelTime = levelTime;
        timerView.UpdateTimeText(levelTime);
    }

    /// <summary>
    /// Starts the timer countdown.
    /// </summary>
    private void StartTimer()
    {
        startCounting = true;
        currentTime = levelTime;
    }

    /// <summary>
    /// Stops the timer countdown.
    /// </summary>
    private void StopTimer()
    {
        startCounting = false;
    }
}

