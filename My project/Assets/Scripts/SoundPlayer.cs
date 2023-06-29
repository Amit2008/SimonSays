using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip, float gameSpeed) 
    {
        audioSource.clip = clip;
        audioSource.pitch = gameSpeed;
        audioSource.Play();

        Destroy(gameObject, clip.length); 
    }
}
