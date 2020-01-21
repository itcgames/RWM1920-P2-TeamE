using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemBox : MonoBehaviour, IDropHandler
{
    public GameObject SlotItem;

    void Start()
    {
    }
    public void OnDrop(PointerEventData eventData)
    {

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public Vector3 getPos()
    {
        return GetComponent<RectTransform>().anchoredPosition;
    }
}
