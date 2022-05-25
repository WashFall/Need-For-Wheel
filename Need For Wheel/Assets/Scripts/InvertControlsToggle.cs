using UnityEngine;
using UnityEngine.UI;

public class InvertControlsToggle : MonoBehaviour
{
    public InputManager inputManager;

    private Toggle toggle;

    // Toggles inverted flight controls through the settings menu
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = PlayerPrefs.GetInt("invertFlying") == 1 ? true : false;
    }

    public void InvertControls()
    {
        InvertedControls.ChangeInvert(toggle.isOn);

        if(inputManager != null) inputManager.invertControls = toggle.isOn;
    }
}
