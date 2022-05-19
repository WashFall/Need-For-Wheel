using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class VolumeSettings
{
    public static void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume / 10);
        PlayerPrefs.Save();
    }
}
