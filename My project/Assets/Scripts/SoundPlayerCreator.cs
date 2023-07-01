using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents the creator of sound players for button sounds.
/// </summary>
public class SoundPlayerCreator : MonoBehaviour
{
    [SerializeField] private GameObject soundPlayerPrefab;
    [SerializeField] private Transform soundsParent;

    private float gameSpeed;

    private void OnEnable()
    {
        GameplayEvents.Instance.ButtonPressed += PlayButtonSound;
    }

    private void OnDisable()
    {
        if (GameplayEvents.Instance == null) return;

        GameplayEvents.Instance.ButtonPressed -= PlayButtonSound;
    }

    /// <summary>
    /// Sets the game speed for the sound manager.
    /// </summary>
    /// <param name="gameSpeed">The game speed value.</param>
    public void SetSoundManager(float gameSpeed)
    {
        this.gameSpeed = gameSpeed;
    }

    /// <summary>
    /// Plays the button sound associated with the provided button model.
    /// </summary>
    /// <param name="buttonModel">The button model containing the button sound.</param>
    private void PlayButtonSound(ButtonModel buttonModel)
    {
        var audioClip = buttonModel.ButtonSound;

        if (audioClip == null)
        {
            Debug.LogError("PlayButtonSound audio clip is null - error");
            return;
        }

        GameObject soundPlayerObj = Instantiate(soundPlayerPrefab, soundsParent);
        SoundPlayer soundPlayerComponent = soundPlayerObj.GetComponent<SoundPlayer>();

        if (soundPlayerComponent == null)
        {
            Debug.LogError("PlayButtonSound: sound player component is null - error");
            return;
        }

        soundPlayerComponent.PlaySound(audioClip, gameSpeed);
    }
}

