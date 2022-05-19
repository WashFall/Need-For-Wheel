using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InvertedControls
{
    public static void ChangeInvert(bool toggle)
    {
        int change = toggle ? 1 : 0;
        PlayerPrefs.SetInt("invertFlying", change);
        PlayerPrefs.Save();
    }
}
