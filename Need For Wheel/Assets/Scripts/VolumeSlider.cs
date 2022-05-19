using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    }
}
