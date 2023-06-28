using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JSONGameConfiguration : GameConfiguration
{
    public override void LoadConfiguration(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            GameConfigurationData configData = JsonConvert.DeserializeObject<GameConfigurationData>(jsonData);

            GameButtons = configData.GameButtons;
            PointsPerStep = configData.PointsPerStep;
            GameTime = configData.GameTime;
            RepeatMode = configData.RepeatMode;
            GameSpeed = configData.GameSpeed;
        }
        else
        {
            Debug.LogError("JSON Configuration file not found at path: " + filePath);
        }
    }
}