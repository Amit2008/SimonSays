using UnityEngine;

public class GameDataInjector : MonoBehaviour 
{
    private GameConfigurationData configurationData;
    [SerializeField] private ButtonGroupCreator buttonGroupCreator;
    [SerializeField] private NewStepMaker newStepMaker;
    [SerializeField] private SequentialStepsPlayer sequentialStepsPlayer;
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
    }
}