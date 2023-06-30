﻿using UnityEngine;

public class GameplayLoader : MonoBehaviour 
{
    private void OnEnable()
    {
        MainMenuEvents.Instance.LevelNameSet += LoadLevel;
    }
    private void OnDisable()
    {
        MainMenuEvents.Instance.LevelNameSet -= LoadLevel;
    }

    private void LoadLevel() 
    {
        GeneralEvents.Instance.GoToGameplay?.Invoke();
    }
}
