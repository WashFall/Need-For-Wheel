using UnityEngine;

public static class InvertedControls
{
    // Saves the setting for inverted flight controls
    public static void ChangeInvert(bool toggle)
    {
        int change = toggle ? 1 : 0;
        PlayerPrefs.SetInt("invertFlying", change);
        PlayerPrefs.Save();
    }
}
