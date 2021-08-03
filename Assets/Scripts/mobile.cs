using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mobile : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image stick;
    private Image childStick;
    private Vector2 inputVector;

    private void Start()
    {
        stick = GetComponent<Image>();
        childStick = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        childStick.rectTransform.anchoredPosition = Vector2.zero;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(stick.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / stick.rectTransform.sizeDelta.x);
            pos.y = (pos.y / stick.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x , pos.y );
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            childStick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (stick.rectTransform.sizeDelta.x / 2), inputVector.y * (stick.rectTransform.sizeDelta.y / 2));
        }    
    }
}
