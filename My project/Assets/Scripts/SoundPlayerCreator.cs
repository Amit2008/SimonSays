using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void SetSoundManager(float gameSpeed) 
    {
        this.gameSpeed = gameSpeed;
    }

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
