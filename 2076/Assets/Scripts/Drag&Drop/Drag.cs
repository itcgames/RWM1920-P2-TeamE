using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canv;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject fan;
    public GameObject myBox;

    public GameObject eventSystem;
    public int COST = 0;

    private Vector3 startPos;
    private void Awake()
    {
        startPos = myBox.GetComponent<ItemBox>().getPos();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost >= COST)
        {
            eventSystem.GetComponent<EventHandling>().updateCost(COST);
        }
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        rectTransform.anchoredPosition += eventData.delta / canv.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;

        Vector3 newPos;
        newPos = Camera.main.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;

        Instantiate(fan, newPos, Quaternion.identity);
        this.transform.position = new Vector3(startPos.x + 17.1f,startPos.y + 1.1f,0);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
