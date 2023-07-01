using UnityEngine;

public class GameConfigurationLoader : MonoBehaviour
{
    [SerializeField, Tooltip("Flag indicating whether to use JSON or XML")] private bool useJSON = true;    // Flag indicating whether to use JSON or XML
    [SerializeField] private string fileName;                                                               // Name of the configuration file

    private void Start()
    {
        fileName = GameplayHelper.FileName;

        if (string.IsNullOrEmpty(fileName)) return;

        string fullUrl = Application.persistentDataPath + "/" + fileName + (useJSON ? ".json" : ".xml");

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

        // Invoke the event to notify that data has been loaded
        GameplayEvents.Instance.DataLoaded?.Invoke(configuration);
    }
}