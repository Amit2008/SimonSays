using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System;

/// <summary>
/// Editor window for creating game configurations.
/// </summary>
public class GameConfigurationCreator : EditorWindow
{
    [Header("Game Configuration Parameters")]
    public int gameButtons;
    public int pointsPerStep;
    public float gameTime;
    public bool repeatMode;
    public float gameSpeed;

    [Space]
    [SerializeField] private string fileName;

    [MenuItem("Window/Game Configuration Creator")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<GameConfigurationCreator>("Game Config Creator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Game Configuration Creator", EditorStyles.boldLabel);

        // Display input fields for game configuration parameters
        gameButtons = EditorGUILayout.IntField("Game Buttons", gameButtons);
        pointsPerStep = EditorGUILayout.IntField("Points Per Step", pointsPerStep);
        gameTime = EditorGUILayout.FloatField("Game Time", gameTime);
        repeatMode = EditorGUILayout.Toggle("Repeat Mode", repeatMode);
        gameSpeed = EditorGUILayout.FloatField("Game Speed", gameSpeed);
        fileName = EditorGUILayout.TextField("File Name", fileName);

        EditorGUILayout.Space();

        // Button to create JSON configuration
        if (GUILayout.Button("Create JSON Configuration"))
        {
            if (!ParametersValid())
            {
                Debug.LogError("Parameters not valid, GameButtons between 2-6, PointsPerStep > 0, GameTime > 0, GameSpeed >= 1, File Name must have a value");
                return;
            }
            CreateJSONConfiguration();
        }

        // Button to create XML configuration
        if (GUILayout.Button("Create XML Configuration"))
        {
            if (!ParametersValid())
            {
                Debug.LogError("Parameters not valid, GameButtons between 2-6, PointsPerStep > 0, GameTime > 0, GameSpeed >= 1, File Name must have a value");
                return;
            }
            CreateXMLConfiguration();
        }
    }

    // Validates the input parameters for the game configuration
    private bool ParametersValid()
    {
        if (gameButtons < 2 || gameButtons > 6) return false;
        if (pointsPerStep <= 0) return false;
        if (gameTime <= 0) return false;
        if (gameSpeed < 1) return false;
        if (string.IsNullOrEmpty(fileName)) return false;
        return true;
    }

    // Creates a JSON configuration file based on the input parameters
    private void CreateJSONConfiguration()
    {
        GameConfigurationData configData = new GameConfigurationData
        {
            GameButtons = gameButtons,
            PointsPerStep = pointsPerStep,
            GameTime = gameTime,
            RepeatMode = repeatMode,
            GameSpeed = gameSpeed
        };

        string jsonData = JsonConvert.SerializeObject(configData, Formatting.Indented);
        string filePath = Application.persistentDataPath + $"/{fileName}.json";
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"JSON Configuration created: {filePath}");

        AssetDatabase.Refresh();
    }

    // Creates an XML configuration file based on the input parameters
    public void CreateXMLConfiguration()
    {
        GameConfigurationData configData = new GameConfigurationData
        {
            GameButtons = gameButtons,
            PointsPerStep = pointsPerStep,
            GameTime = gameTime,
            RepeatMode = repeatMode,
            GameSpeed = gameSpeed
        };

        XmlSerializer serializer = new XmlSerializer(typeof(GameConfigurationData));
        using (StreamWriter streamWriter = new StreamWriter(Application.persistentDataPath + $"/{fileName}.xml"))
        {
            serializer.Serialize(streamWriter, configData);
        }

        Debug.Log($"XML Configuration created: {Application.persistentDataPath}/{fileName}.xml");

        AssetDatabase.Refresh();
    }

    /// <summary>
    /// Data structure representing the game configuration parameters.
    /// </summary>
    [Serializable]
    public class GameConfigurationData
    {
        public int GameButtons;
        public int PointsPerStep;
        public float GameTime;
        public bool RepeatMode;
        public float GameSpeed;
    }
}
