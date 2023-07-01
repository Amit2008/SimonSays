using UnityEngine;

/// <summary>
/// Represents a player for playing sounds using an AudioSource component.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the specified audio clip with the given game speed.
    /// </summary>
    /// <param name="clip">The audio clip to be played.</param>
    /// <param name="gameSpeed">The game speed to apply to the pitch of the audio source.</param>
    public void PlaySound(AudioClip clip, float gameSpeed)
    {
        audioSource.clip = clip;
        audioSource.pitch = gameSpeed;
        audioSource.Play();

        Destroy(gameObject, clip.length);
    }
}

