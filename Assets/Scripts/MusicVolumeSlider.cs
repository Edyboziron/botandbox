using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Connects a UI Slider to MusicManager for real-time volume adjustment.
/// </summary>
public class MusicVolumeSlider : MonoBehaviour
{
    [Header("UI Components")]
    [Tooltip("Volume control slider.")]
    public Slider volumeSlider;

    [Tooltip("Optional text element to display percentage (e.g., 75%).")]
    public Text volumeText;

    private void Start()
    {
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.RegisterSlider(this);

            if (volumeSlider != null)
            {
                volumeSlider.value = MusicManager.Instance.GetVolume();
                volumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
            }
        }
        else
        {
            Debug.LogWarning("MusicManager.Instance is null. Ensure MusicManager exists in the scene.");
        }

        if (volumeSlider != null && volumeSlider.wholeNumbers)
        {
            Debug.LogWarning(gameObject.name + " slider has 'Whole Numbers' enabled. Disable it for smooth volume control.");
        }
    }

    private void OnSliderValueChanged(float value)
    {
        MusicManager.Instance?.SetVolume(value);

        if (volumeText != null)
        {
            volumeText.text = Mathf.RoundToInt(value * 100) + "%";
        }
    }

    /// <summary>
    /// Updates the slider position and text from current MusicManager state.
    /// </summary>
    public void UpdateSliderUI()
    {
        if (MusicManager.Instance != null && volumeSlider != null)
        {
            float vol = MusicManager.Instance.GetVolume();
            volumeSlider.value = vol;

            if (volumeText != null)
            {
                volumeText.text = Mathf.RoundToInt(vol * 100) + "%";
            }
        }
    }
}
