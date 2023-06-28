using System;

public class GameplayEvents : MonoSingleton<GameplayEvents> 
{
    public Action<GameConfigurationData> DataLoaded; // Whenever the data is loaded, this event will be invoked.
    public Action<ButtonModel> ButtonPressed; // Whenever a button is pressed, this event will be invoked.
}