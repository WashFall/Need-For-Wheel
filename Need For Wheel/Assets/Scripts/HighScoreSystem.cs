using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    public PlayerController player;
    public GameObject pointCanvas;

    private float points;
    private List<float> scoresList = new List<float>();

    void Start()
    {
        try
        {
            if (!PlayerPrefs.HasKey("hScore1"))
                throw new System.Exception();
        }
        catch (System.Exception)
        {
            CreateScores();
        }
        finally
        {
            for (int i = 1; i < 6; i++)
            {
                scoresList.Add(PlayerPrefs.GetFloat(string.Format("hScore{0}", i)));
            }
        }
    }

    void CreateScores()
    {
        float setInitialPoints = 90000f;
        for( int i = 1; i < 6; i++)
        {
            PlayerPrefs.SetFloat(string.Format("hScore{0}", i), setInitialPoints);
            setInitialPoints -= 10000f;
        }

        PlayerPrefs.Save();
    }
}
