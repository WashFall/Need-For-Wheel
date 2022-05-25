using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public Slider volume;

    // Sets the number above the volume slider to represent the correct volume
    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = (volume.value * 10).ToString();
    }
}
