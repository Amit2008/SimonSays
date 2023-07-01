using UnityEngine;

/// <summary>
/// Handles loading the gameplay scene when the level name is set.
/// </summary>
public class GameplayLoader : MonoBehaviour
{
    private void OnEnable()
    {
        // Subscribe to the LevelNameSet event of the MainMenuEvents instance.
        MainMenuEvents.Instance.LevelNameSet += LoadLevel;
    }

    private void OnDisable()
    {
        if (MainMenuEvents.Instance == null) return;

        // Unsubscribe from the LevelNameSet event of the MainMenuEvents instance.
        MainMenuEvents.Instance.LevelNameSet -= LoadLevel;
    }

    private void LoadLevel()
    {
        // Trigger the GoToGameplay event of the GeneralEvents instance to load the gameplay scene.
        GeneralEvents.Instance.GoToGameplay?.Invoke();
    }
}
