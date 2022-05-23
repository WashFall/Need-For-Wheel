using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CreditsMenu : MonoBehaviour
{
    private void OnEnable()
    {
        if (EventSystem.current?.currentSelectedGameObject)
            EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TMP_Text>().color 
            = new Color32(233, 165, 6, 255);
    }
}
