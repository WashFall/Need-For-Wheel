using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    public Text fuelDisplay;

    private void Update()
    {
        fuelDisplay.text = "FUEL: " + BoostSystem.boost.ToString();
    }
}
