using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class ButtonHandler : MonoBehaviour, 
    IPointerEnterHandler, IPointerDownHandler, 
    ISelectHandler, ISubmitHandler, IDeselectHandler, IPointerExitHandler
{
    private Color32 orangeish;
    private TMP_Text text;
    private string textCopy;

    void Start()
    {
        orangeish = new Color32(233, 165, 6, 255);
        text = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        textCopy = text.text;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        text.text = "MEOW";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = orangeish;
    }

    public void OnSelect(BaseEventData eventData)
    {
        text.color = orangeish;
    }

    public void OnSubmit(BaseEventData eventData)
    {
        text.text = "MEOW";
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = Color.white;
    }
}
