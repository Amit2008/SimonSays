using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnterNamePopupView))]
public class EnterNamePopupController : MonoBehaviour
{
    private EnterNamePopupView popupView;
    private PlayerNameSaver playerNameSaver;

    private void Awake()
    {
        popupView = GetComponent<EnterNamePopupView>();
        playerNameSaver = new PlayerNameSaver();
    }
    private void Start()
    {
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
        popupView.ConitueClicked += ClosePopup;
        popupView.InputFieldEditingEnded += CheckNameValidation;
    }
    private void OnDisable()
    {
        if (popupView == null) return;

        popupView.ConitueClicked -= ClosePopup;
        popupView.InputFieldEditingEnded -= CheckNameValidation;
    }

    private void ClosePopup()
    {
        MainMenuEvents.Instance.NameIsValid?.Invoke(popupView.InputFieldText);
        gameObject.SetActive(false);
    }

    private void CheckNameValidation(string name) 
    {
        popupView.SetContinueButtonInteractableState(!string.IsNullOrEmpty(name));
    }
}
