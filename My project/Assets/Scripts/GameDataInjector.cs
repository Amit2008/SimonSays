using UnityEngine;

public class GameDataInjector : MonoBehaviour 
{
    private GameConfigurationData configurationData;
    [SerializeField] private ButtonGroupCreator buttonGroupCreator;
    public void SaveData(GameConfigurationData configurationData) 
    {
        this.configurationData = configurationData;
        InjectData();
    }

    private void InjectData() 
    {
        buttonGroupCreator.SetAmountOfButtons(configurationData.GameButtons);
    }
}