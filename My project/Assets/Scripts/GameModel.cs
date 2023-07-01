using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the game model that handles injecting game data into the relevant components.
/// </summary>
[RequireComponent(typeof(GameDataInjector))]
public class GameModel : MonoBehaviour
{
    private GameDataInjector gameDataInjector;

    private void Awake()
    {
        // Get the reference to the GameDataInjector component attached to this GameObject.
        gameDataInjector = GetComponent<GameDataInjector>();
    }

    private void OnEnable()
    {
        // Subscribe to the DataLoaded event of the GameplayEvents instance.
        GameplayEvents.Instance.DataLoaded += SetDataInjector;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;
        // Unsubscribe from the DataLoaded event of the GameplayEvents instance.
        GameplayEvents.Instance.DataLoaded -= SetDataInjector;
    }

    private void SetDataInjector(GameConfigurationData data)
    {
        // Pass the game configuration data to the GameDataInjector to save and inject the data.
        gameDataInjector.SaveData(data);
    }
}

