using System.Collections.Generic;
using UnityEngine;

public class HighScoreSystem : MonoBehaviour
{
    public GameObject pointCanvas;
    public PlayerController player;
    public FinishLineCollider finish;

    private bool saved;
    private List<float> scoresList = new List<float>();

    void Start()
    {
        CheckIfScoreExist();
    }

    void Update()
    {
        SaveScore();
    }

    void CheckIfScoreExist() // Either load existing scores or create new ones
    {
        try
        {
            if (!PlayerPrefs.HasKey("hScore1")) throw new System.Exception();
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

    void SaveScore() // Save score when the game is completed
    {
        if (finish.collideOnce && !saved)
        {
            for (int i = 0; i < 5; i++)
            {
                if (PointSystem.points > scoresList[i])
                {
                    scoresList.Insert(i, PointSystem.points);
                    break;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetFloat(string.Format("hScore{0}", i + 1), scoresList[i]);
            }

            PlayerPrefs.Save();
            saved = true;
        }
    }
}
