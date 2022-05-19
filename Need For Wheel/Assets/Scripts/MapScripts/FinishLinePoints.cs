using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishLinePoints : MonoBehaviour
{
    public TMP_Text pointsDisplay;
    public TMP_Text hScore1, hScore2, hScore3, hScore4, hScore5;

    private List<TMP_Text> texts = new List<TMP_Text>();
    private Color orangeish;

    private void Start()
    {
        texts.Add(hScore1);
        texts.Add(hScore2);
        texts.Add(hScore3);
        texts.Add(hScore4);
        texts.Add(hScore5);
        orangeish = new Color32(233, 165, 6, 255);
    }

    private void Update()
    {
        pointsDisplay.text = "YOUR SCORE: " + PointSystem.points.ToString();
        hScore1.text = "1. " + PlayerPrefs.GetFloat("hScore1");
        hScore2.text = "2. " + PlayerPrefs.GetFloat("hScore2");
        hScore3.text = "3. " + PlayerPrefs.GetFloat("hScore3");
        hScore4.text = "4. " + PlayerPrefs.GetFloat("hScore4");
        hScore5.text = "5. " + PlayerPrefs.GetFloat("hScore5");
        foreach(TMP_Text text in texts)
        {
            string score = text.text.Substring(3, text.text.Length - 3);
            if(score == PointSystem.points.ToString())
            {
                text.color = orangeish;
            }
        }
    }
}
