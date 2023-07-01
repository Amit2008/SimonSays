using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelButtonView))]
public class LevelButtonController : MonoBehaviour
{
    private string levelName;
    private LevelButtonView levelButtonView;

    private void Awake()
    {
        levelButtonView = GetComponent<LevelButtonView>();
    }

    private void OnEnable()
    {
        levelButtonView.LevelButtonClicked += SetLevelNameToLoad;
        MainMenuEvents.Instance.LevelNameSet += DisableInteractivity;
    }

    private void OnDisable()
    {
        if (MainMenuEvents.Instance == null || levelButtonView == null) return;

        levelButtonView.LevelButtonClicked -= SetLevelNameToLoad;
        MainMenuEvents.Instance.LevelNameSet -= DisableInteractivity;
    }

    /// <summary>
    /// Sets the level name and updates the button's text.
    /// </summary>
    public void SetButton(string levelName)
    {
        this.levelName = levelName;
        levelButtonView.SetButtonText(levelName.ToUpper());
    }

    /// <summary>
    /// Sets the level name to load in the game system when the button is clicked.
    /// </summary>
    private void SetLevelNameToLoad()
    {
        GameplayHelper.FileName = levelName;
        MainMenuEvents.Instance.LevelNameSet?.Invoke();
    }

    /// <summary>
    /// Disables the interaction state of the button.
    /// </summary>
    private void DisableInteractivity()
    {
        levelButtonView.SetInteractionState(false);
    }
}

