using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract base class for game configuration
public abstract class GameConfiguration : GameConfigurationData
{
    // Abstract method to load the configuration data from a specific file
    public abstract void LoadConfiguration(string filePath);
}

// Data structure for game configuration
[Serializable]
public class GameConfigurationData
{
    public int GameButtons;      // Number of game buttons
    public int PointsPerStep;    // Points awarded per step
    public float GameTime;       // Total game time
    public bool RepeatMode;      // Indicates if the sequence should be repeated after each turn
    public float GameSpeed;      // Extra game speed
}
