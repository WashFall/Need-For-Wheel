using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

    // Reads the value of the volume slider and sends calls to save it and update audio sources
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volume") * 10;
    }

    public void SetVolume()
    {
        VolumeSettings.ChangeVolume(slider.value);
        ServiceLocator.GetAudioService().UpdateSound();
    }
}
