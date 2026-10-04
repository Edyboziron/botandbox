using UnityEngine;

/// <summary>
/// Plays background music in a scene with automatic looping.
/// </summary>
public class SceneMusic : MonoBehaviour
{
    [Tooltip("Music clip to loop in the scene.")]
    public AudioClip musicClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }
}
