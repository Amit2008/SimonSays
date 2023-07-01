using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the behavior of the Enter Name Popup.
/// It handles user input, validation, and saving the player name.
/// </summary>
[RequireComponent(typeof(EnterNamePopupView))]
public class EnterNamePopupController : MonoBehaviour
{
    private EnterNamePopupView popupView;
    private PlayerNameSaver playerNameSaver;

    private void Awake()
    {
        // Get references to the required components
        popupView = GetComponent<EnterNamePopupView>();
        playerNameSaver = new PlayerNameSaver();
    }

    private void Start()
    {
        // Load the player name from PlayerPrefs and initialize the UI state
        string playerName = PlayerPrefs.GetString(GameConstants.PlayerNameKey, "");

        if (!string.IsNullOrEmpty(playerName))
        {
            popupView.SetInputField(playerName);
            popupView.SetContinueButtonInteractableState(true);
        }
        else
        {
            popupView.SetContinueButtonInteractableState(false);
        }
    }

    private void OnEnable()
    {
        // Subscribe to events for user input and interaction
        popupView.ConitueClicked += ClosePopup;
        popupView.InputFieldEditingEnded += CheckNameValidation;
    }

    private void OnDisable()
    {
        // Unsubscribe from events to avoid memory leaks
        if (popupView == null) return;

        popupView.ConitueClicked -= ClosePopup;
        popupView.InputFieldEditingEnded -= CheckNameValidation;
    }

    private void ClosePopup()
    {
        // Save the player name and notify listeners that the name is valid
        MainMenuEvents.Instance.NameIsValid?.Invoke(popupView.InputFieldText);
        gameObject.SetActive(false);
    }

    private void CheckNameValidation(string name)
    {
        // Enable or disable the continue button based on name validation
        popupView.SetContinueButtonInteractableState(!string.IsNullOrEmpty(name));
    }
}

