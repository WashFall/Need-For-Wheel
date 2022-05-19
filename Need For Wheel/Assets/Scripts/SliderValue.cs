using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider volume;

    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = (volume.value * 10).ToString();
    }
}
