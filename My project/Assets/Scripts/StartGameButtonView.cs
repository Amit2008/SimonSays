using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the view component for the start game button.
/// </summary>
public class StartGameButtonView : MonoBehaviour
{
    public Action StartButtonClicked; // Event triggered when the start button is clicked.

    /// <summary>
    /// Invokes the StartButtonClicked event when the start button is clicked.
    /// </summary>
    public void OnStartButtonClick()
    {
        StartButtonClicked?.Invoke();
    }
}

