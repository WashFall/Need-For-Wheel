using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    public Image fuelDisplay;

    private void Update()
    {
        fuelDisplay.fillAmount = BoostSystem.boost / 1760;
    }
}
