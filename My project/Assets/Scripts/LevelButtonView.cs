using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelButtonView : MonoBehaviour
{
    public Action LevelButtonClicked;
    [SerializeField] private TextMeshProUGUI buttonText;
    
    public void OnLevelButtonClick() 
    {
        LevelButtonClicked?.Invoke();
    }

    public void SetButtonText(string text) 
    {
        buttonText.text = text;
    }
}
