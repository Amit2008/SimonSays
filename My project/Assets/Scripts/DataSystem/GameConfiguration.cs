using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameConfiguration : GameConfigurationData
{    
    // Abstract method to load the configuration data from a specific file
    public abstract void LoadConfiguration(string filePath);
}

[Serializable]
public class GameConfigurationData 
{
    public int GameButtons;
    public int PointsPerStep;
    public float GameTime;
    public bool RepeatMode;
    public float GameSpeed;
}
