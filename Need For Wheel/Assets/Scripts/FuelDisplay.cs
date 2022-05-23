using UnityEngine;
using UnityEngine.UI;

public class FuelDisplay : MonoBehaviour
{
    public Image fuelDisplay;

    // To make the boost display fill up when gaining boost
    private void Update()
    {
        fuelDisplay.fillAmount = BoostSystem.boost / 1760;
    }
}
