using UnityEngine;

/// <summary>
/// Saves the player's name using PlayerPrefs when a valid name is received.
/// </summary>
public class PlayerNameSaver
{
    public PlayerNameSaver()
    {
        MainMenuEvents.Instance.NameIsValid += SaveName;
    }

    /// <summary>
    /// Saves the player's name using PlayerPrefs.
    /// </summary>
    /// <param name="name">The player's name.</param>
    private void SaveName(string name)
    {
        PlayerPrefs.SetString(GameConstants.PlayerNameKey, name);
        PlayerPrefs.Save();
        MainMenuEvents.Instance.NameIsValid -= SaveName;
    }
}

