using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public partial class XMLGameConfiguration : GameConfiguration
{
    public override void LoadConfiguration(string filePath)
    {
        if (File.Exists(filePath))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(GameConfigurationData));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                GameConfigurationData configData = (GameConfigurationData )serializer.Deserialize(stream);

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
