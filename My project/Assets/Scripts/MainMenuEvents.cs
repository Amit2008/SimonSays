using System;

public class MainMenuEvents : MonoSingleton<MainMenuEvents> 
{
    public Action<string> NameIsValid; // This is the event that will be invoked when the name is saved.
    public Action LevelNameSet; // This is the event that will be invoked when the level name is set.
}
