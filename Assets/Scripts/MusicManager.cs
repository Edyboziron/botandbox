using UnityEngine;

/// <summary>
/// Singleton manager for background music playback, volume settings, and persistence across scenes.
/// </summary>
public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private AudioSource audioSource;
    private bool isMuted = false;
    private float volume = 1f;
    private MusicVolumeSlider slider;
    private float lastVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();

            // Load saved settings
            isMuted = PlayerPrefs.GetInt("musicMuted", 0) == 1;
            volume = PlayerPrefs.GetFloat("musicVolume", 1f);

            if (audioSource != null)
            {
                audioSource.volume = volume;
                audioSource.mute = isMuted;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Toggles music between muted and previous volume level.
    /// </summary>
    public void ToggleMusic()
    {
        if (volume > 0f)
        {
            lastVolume = volume;
            SetVolume(0f);
        }
        else
        {
            SetVolume(lastVolume > 0f ? lastVolume : 1f);
        }

        slider?.UpdateSliderUI();
    }

    /// <summary>
    /// Updates music volume and persists to PlayerPrefs.
    /// </summary>
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (audioSource != null)
        {
            audioSource.volume = volume;
            isMuted = volume <= 0f;
            audioSource.mute = isMuted;
        }

        PlayerPrefs.SetFloat("musicVolume", volume);
        PlayerPrefs.SetInt("musicMuted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        slider?.UpdateSliderUI();
    }

    public float GetVolume()
    {
        return volume;
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    public void RefreshVolume()
    {
        if (audioSource != null)
        {
            audioSource.volume = isMuted ? 0f : volume;
        }
    }

    public void RegisterSlider(MusicVolumeSlider newSlider)
    {
        slider = newSlider;
        slider.UpdateSliderUI();
    }
}
