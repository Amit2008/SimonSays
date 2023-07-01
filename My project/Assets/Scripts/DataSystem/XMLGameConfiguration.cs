using UnityEngine;
using System.IO;
using System.Xml.Serialization;

// Game configuration loaded from XML file
public class XMLGameConfiguration : GameConfiguration
{
    public override void LoadConfiguration(string filePath)
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfigurationData));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                GameConfigurationData configData = (GameConfigurationData)serializer.Deserialize(stream);

                // Set the configuration data
                GameButtons = configData.GameButtons;
                PointsPerStep = configData.PointsPerStep;
                GameTime = configData.GameTime;
                RepeatMode = configData.RepeatMode;
                GameSpeed = configData.GameSpeed;
            }
        }
        else
        {
            Debug.LogError("XML Configuration file not found at path: " + filePath);
        }
    }
}
