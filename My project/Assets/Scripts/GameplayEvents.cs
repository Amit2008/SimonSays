using System;
using System.Collections.Generic;

public class GameplayEvents : MonoSingleton<GameplayEvents> 
{
    public Action<GameConfigurationData> DataLoaded; // Whenever the data is loaded, this event will be invoked.
    public Action<ButtonModel> ButtonPressed; // Whenever a button is pressed, this event will be invoked.    
    public Action StartButtonClicked; // Whenever the start button is clicked, this event will be invoked.
    public Action<List<ButtonType>> NewStepMade; // Whenever a new step is made, this event will be invoked.
    public Action SystemStartPlayingSteps; // Whenever the system starts playing the steps, this event will be invoked.
    public Action<ButtonType, float> SystemPlayedStep; // Whenever a step is played by the system, this event will be invoked.
    public Action SystemPlayedAllSteps; // Whenever the system played all the steps, this event will be invoked.
    public Action PlayerMadeBadSequence; // Whenever the player made a bad sequence, this event will be invoked.
    public Action PlayerFinishedSequenceSuccessfully; // Whenever the player made a bad sequence, this event will be invoked.
}