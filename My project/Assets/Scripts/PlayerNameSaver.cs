using UnityEngine;

public class PlayerNameSaver 
{
    public PlayerNameSaver() 
    {
        MainMenuEvents.Instance.NameIsValid += SaveName;
    }

    private void SaveName(string name)
    {
        PlayerPrefs.SetString(GameConstants.PlayerNameKey, name);
        PlayerPrefs.Save();
        MainMenuEvents.Instance.NameIsValid -= SaveName;
    }
}
