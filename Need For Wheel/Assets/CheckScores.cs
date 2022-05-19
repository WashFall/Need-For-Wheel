using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScores : MonoBehaviour
{
    void Start()
    {
        Debug.Log(PlayerPrefs.HasKey("hScore1"));
        Debug.Log(PlayerPrefs.HasKey("hScore2"));
        Debug.Log(PlayerPrefs.HasKey("hScore3"));
        Debug.Log(PlayerPrefs.HasKey("hScore4"));
        Debug.Log(PlayerPrefs.HasKey("hScore5"));
    }
}
