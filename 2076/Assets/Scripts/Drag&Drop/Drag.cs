using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canv;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject fan;
    public GameObject myBox;

    public GameObject eventSystem;
    public int COST = 0;
    private bool useable = true;

    private Vector3 startPos;
    private Image img;

    public GameObject m_manager;
    private void Awake()
    {
        img = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (useable == true)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (useable == true)
        {
            rectTransform.anchoredPosition += eventData.delta / canv.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (useable == true)
        {
            if (SceneManager.GetActiveScene().name != "Custom")
            {
                if (eventSystem.GetComponent<EventHandling>().currentCost >= COST)
                {
                    eventSystem.GetComponent<EventHandling>().updateCost(COST);
                }
            }
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1.0f;
            rectTransform.anchoredPosition = myBox.GetComponent<RectTransform>().anchoredPosition;


            Vector3 newPos;
            newPos = Camera.main.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;

            GameObject newGameObject = Instantiate(fan, newPos, fan.transform.rotation);
            m_manager.GetComponent<Manager>().createdObjs.Add(newGameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private void Update()
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost < COST)
        {
            useable = false;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
        }
        else
        {
            useable = true;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);

        }
    }
}
