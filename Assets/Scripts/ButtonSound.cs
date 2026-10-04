using UnityEngine;

/// <summary>
/// Plays an audio clip when UI buttons are clicked.
/// </summary>
public class ButtonSound : MonoBehaviour
{
    [Tooltip("Sound clip played on button click.")]
    public AudioClip clickSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayClickSound()
    {
        if (clickSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
