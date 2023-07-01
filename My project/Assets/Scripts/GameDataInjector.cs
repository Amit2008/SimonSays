using UnityEngine;

/// <summary>
/// Handles injecting game configuration data into relevant game components.
/// </summary>
public class GameDataInjector : MonoBehaviour
{
    private GameConfigurationData configurationData;

    [SerializeField] private ButtonGroupCreator buttonGroupCreator;
    [SerializeField] private NewStepMaker newStepMaker;
    [SerializeField] private SequentialStepsPlayer sequentialStepsPlayer;
    [SerializeField] private SoundPlayerCreator soundManager;
    [SerializeField] private ScoreIncrementorController scoreIncrementorController;
    [SerializeField] private TimerController timerController;

    /// <summary>
    /// Saves the game configuration data and injects it into the relevant components.
    /// </summary>
    /// <param name="configurationData">The game configuration data.</param>
    public void SaveData(GameConfigurationData configurationData)
    {
        this.configurationData = configurationData;
        InjectData();
    }

    private void InjectData()
    {
        // Inject the game configuration data into the relevant components.
        buttonGroupCreator.SetAmountOfButtons(configurationData.GameButtons);
        newStepMaker.SetMaximumButtonAmount(configurationData.GameButtons);
        sequentialStepsPlayer.SetStepsPlayer(configurationData.RepeatMode, configurationData.GameSpeed);
        soundManager.SetSoundManager(configurationData.GameSpeed);
        scoreIncrementorController.SetScorePerStep(configurationData.PointsPerStep);
        timerController.SetTimer(configurationData.GameTime);
    }
}
