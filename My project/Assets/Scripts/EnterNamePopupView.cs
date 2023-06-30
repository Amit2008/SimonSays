using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterNamePopupView : MonoBehaviour
{
    public Action<string> InputFieldEditingEnded;
    public Action ConitueClicked;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button continueButton;

    public string InputFieldText => inputField.text;
    
    public void OnEndEdit() 
    {
        InputFieldEditingEnded?.Invoke(inputField.text);
    }

    public void OnContinueClicked() 
    {
        ConitueClicked?.Invoke();
    }

    public void SetContinueButtonInteractableState(bool state) 
    {
        continueButton.interactable = state;
    }

    public void SetInputField(string text) 
    {
        inputField.text = text;
    }
}
