using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CreditsMenu : MonoBehaviour
{
    // To make sure a button gets colored when selected
    private void OnEnable()
    {
        if (EventSystem.current?.currentSelectedGameObject)
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().color 
            = new Color32(233, 165, 6, 255);
    }
}
