using System;

public class GeneralEvents : MonoSingleton<GeneralEvents> 
{
    public Action LevelReadyToBeLoaded; // This event is raised when the level is ready to be loaded.
    public Action<string> GoToMainMenu; // This event is raised when the player wants to go to the main menu.
}
