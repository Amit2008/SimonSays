using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class represents the view for the Enter Name Popup.
/// It handles UI events and provides methods to update the UI state.
/// </summary>
public class EnterNamePopupView : MonoBehaviour
{
    public Action<string> InputFieldEditingEnded;
    public Action ConitueClicked;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button continueButton;

    /// <summary>
    /// Gets the text entered in the input field.
    /// </summary>
    public string InputFieldText => inputField.text;

    /// <summary>
    /// Called when the input field editing ends.
    /// Invokes the InputFieldEditingEnded event with the entered text.
    /// </summary>
    public void OnEndEdit()
    {
        InputFieldEditingEnded?.Invoke(inputField.text);
    }

    /// <summary>
    /// Called when the continue button is clicked.
    /// Invokes the ConitueClicked event.
    /// </summary>
    public void OnContinueClicked()
    {
        ConitueClicked?.Invoke();
    }

    /// <summary>
    /// Sets the interactable state of the continue button.
    /// </summary>
    public void SetContinueButtonInteractableState(bool state)
    {
        continueButton.interactable = state;
    }

    /// <summary>
    /// Sets the text of the input field.
    /// </summary>
    public void SetInputField(string text)
    {
        inputField.text = text;
    }
}
