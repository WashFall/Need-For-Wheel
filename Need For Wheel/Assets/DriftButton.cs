using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DriftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public InputManager inputManager;

    public void OnPointerDown(PointerEventData eventData)
    {
        inputManager.DriftSet();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputManager.DriftReset();
    }
}
