using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeSlider : MonoBehaviour
{
    public Slider volumeSlider;

    void Start()
    {
        if (volumeSlider != null)
        {
            // Initialize slider to current volume
            volumeSlider.value = MusicPlayer.Instance.GetVolume();
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }
    }

    void OnVolumeChanged(float newVolume)
    {
        MusicPlayer.Instance.SetVolume(newVolume);
    }
}
