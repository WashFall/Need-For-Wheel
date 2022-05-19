using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScores : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PlayerPrefs.GetFloat("hScore1"));
        Debug.Log(PlayerPrefs.GetFloat("hScore2"));
        Debug.Log(PlayerPrefs.GetFloat("hScore3"));
        Debug.Log(PlayerPrefs.GetFloat("hScore4"));
        Debug.Log(PlayerPrefs.GetFloat("hScore5"));

        string longString = "1. 80000";
        string sub = longString.Substring(3, longString.Length - 3);
        Debug.Log(sub);
    }
}
