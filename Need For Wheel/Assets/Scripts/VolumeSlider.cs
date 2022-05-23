using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider;

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
