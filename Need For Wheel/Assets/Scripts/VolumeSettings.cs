using UnityEngine;

public static class VolumeSettings
{
    public static void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume / 10);
        PlayerPrefs.Save();
    }
}
