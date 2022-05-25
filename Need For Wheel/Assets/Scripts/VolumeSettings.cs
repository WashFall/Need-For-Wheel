using UnityEngine;

public static class VolumeSettings
{
    // Saves the volume the player wants
    public static void ChangeVolume(float volume)
    {
        PlayerPrefs.SetFloat("volume", volume / 10);
        PlayerPrefs.Save();
    }
}
