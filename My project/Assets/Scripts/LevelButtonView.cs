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
        button= GetComponent<Button>();
    }
    public void OnLevelButtonClick() 
    {
        LevelButtonClicked?.Invoke();
    }

    public void SetButtonText(string text) 
    {
        buttonText.text = text;
    }
    public void SetInteractionState(bool state) 
    {
        button.interactable = state;
    }
}
