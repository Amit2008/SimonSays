using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TimerView))]
public class TimerController : MonoBehaviour
{
    private TimerView timerView;
    private float levelTime;
    private float currentTime = 0;
    private bool startCounting = false;
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

    public void SetTimer(float levelTime)
    {
        this.levelTime = levelTime;
        timerView.UpdateTimeText(levelTime);
    }

    private void StartTimer() 
    {
        startCounting = true;
        currentTime = levelTime;
    }

    private void StopTimer() 
    {
        startCounting = false;
    }
}
