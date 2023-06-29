using UnityEngine;

public class GameDataInjector : MonoBehaviour 
{
    private GameConfigurationData configurationData;
    [SerializeField] private ButtonGroupCreator buttonGroupCreator;
    [SerializeField] private NewStepMaker newStepMaker;
    [SerializeField] private SequentialStepsPlayer sequentialStepsPlayer;
    [SerializeField] private SoundPlayerCreator soundManager;
    [SerializeField] private ScoreIncrementorController scoreIncrementorController;
    [SerializeField] private TimerController timerController;
    public void SaveData(GameConfigurationData configurationData) 
    {
        this.configurationData = configurationData;
        InjectData();
    }

    private void InjectData() 
    {
        buttonGroupCreator.SetAmountOfButtons(configurationData.GameButtons);
        newStepMaker.SetMaximumButtonAmount(configurationData.GameButtons);
        sequentialStepsPlayer.SetStepsPlayer(configurationData.RepeatMode, configurationData.GameSpeed);
        soundManager.SetSoundManager(configurationData.GameSpeed);
        scoreIncrementorController.SetScorePerStep(configurationData.PointsPerStep);
        timerController.SetTimer(configurationData.GameTime);
    }
}