using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameDataInjector))]
public class GameModel : MonoBehaviour
{
    private GameDataInjector gameDataInjector;

    private void Awake()
    {
        gameDataInjector = GetComponent<GameDataInjector>();
    }

    private void OnEnable()
    {
        GameplayEvents.Instance.DataLoaded += SetDataInjector;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;
        GameplayEvents.Instance.DataLoaded -= SetDataInjector;
    }
    private void SetDataInjector(GameConfigurationData data)
    {
        gameDataInjector.SaveData(data);
    }
}
