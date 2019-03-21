using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        ClickableFlag.clickable = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ClickableFlag.clickable = true;
    }
}
