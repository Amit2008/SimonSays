using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the controller for the start game button.
/// </summary>
[RequireComponent(typeof(StartGameButtonView))]
public class StartButtonController : MonoBehaviour
{
    private StartGameButtonView startGameButtonView;

    private void Awake()
    {
        startGameButtonView = GetComponent<StartGameButtonView>();
    }

    private void OnEnable()
    {
        startGameButtonView.StartButtonClicked += HandleStartButtonClick;
    }

    private void OnDisable()
    {
        startGameButtonView.StartButtonClicked -= HandleStartButtonClick;
    }

    /// <summary>
    /// Handles the start button click event.
    /// Triggers the StartButtonClicked event and deactivates the button.
    /// </summary>
    private void HandleStartButtonClick()
    {
        GameplayEvents.Instance.StartButtonClicked?.Invoke();
        gameObject.SetActive(false);
    }
}

