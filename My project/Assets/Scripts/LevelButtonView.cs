using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButtonView : MonoBehaviour
{
    public Action LevelButtonClicked;
    [SerializeField] private TextMeshProUGUI buttonText;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    /// <summary>
    /// Invokes the LevelButtonClicked event when the button is clicked.
    /// </summary>
    public void OnLevelButtonClick()
    {
        LevelButtonClicked?.Invoke();
    }

    /// <summary>
    /// Sets the text of the button.
    /// </summary>
    public void SetButtonText(string text)
    {
        buttonText.text = text;
    }

    /// <summary>
    /// Sets the interaction state of the button.
    /// </summary>
    public void SetInteractionState(bool state)
    {
        button.interactable = state;
    }
}

