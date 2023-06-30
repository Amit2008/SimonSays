using UnityEngine;

public class GameConfigurationLoader : MonoBehaviour
{
    [SerializeField] private bool useJSON = true;
    [SerializeField] private string fileName;
    private void Start()
    {
        if (string.IsNullOrEmpty(fileName)) return;

        string fullUrl =  Application.persistentDataPath + "/" + fileName + (useJSON ? ".json" : ".xml");
        // Create a factory instance based on the chosen configuration type
        ConfigurationFactory factory;

        if (useJSON)
        {
            factory = new JSONConfigurationFactory();
        }
        else
        {
            factory = new XMLConfigurationFactory();
        }

        // Create a configuration object using the factory
        GameConfiguration configuration = factory.CreateConfiguration();

        // Load the configuration data from the file
        configuration.LoadConfiguration(fullUrl);

        // Access the loaded configuration data
        int gameButtons = configuration.GameButtons;
        int pointsPerStep = configuration.PointsPerStep;
        float gameTime = configuration.GameTime;
        bool repeatMode = configuration.RepeatMode;
        float gameSpeed = configuration.GameSpeed;

        // Use the configuration data as needed in your game
        Debug.Log("Game Buttons: " + gameButtons);
        Debug.Log("Points Per Step: " + pointsPerStep);
        Debug.Log("Game Time: " + gameTime);
        Debug.Log("Repeat Mode: " + repeatMode);
        Debug.Log("Game Speed: " + gameSpeed);
        GameplayEvents.Instance.DataLoaded?.Invoke(configuration);
    }
}