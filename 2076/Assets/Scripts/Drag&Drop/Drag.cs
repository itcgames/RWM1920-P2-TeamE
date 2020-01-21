﻿using System.Collections;
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
    Vector3 newPos;

    bool selected = false;


    private void Awake()
    {
        img = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        selected = true;
        if (useable == true && m_manager.GetComponent<Manager>().isPlay == false)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (useable == true && m_manager.GetComponent<Manager>().isPlay == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canv.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (useable == true && m_manager.GetComponent<Manager>().isPlay == false && EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (SceneManager.GetActiveScene().name != "Custom")
            {
                if (fan.gameObject.tag != "PortalExit")
                {
                    if (eventSystem.GetComponent<EventHandling>().currentCost >= COST)
                    {
                        eventSystem.GetComponent<EventHandling>().updateCost(COST);
                    }
                }
            }
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1.0f;
            rectTransform.anchoredPosition = myBox.GetComponent<RectTransform>().anchoredPosition;

            Vector3 newPos;
            newPos = Camera.main.ScreenToWorldPoint(eventData.position);
            newPos.z = 0;

            GameObject newGameObject = Instantiate(fan, newPos, rectTransform.rotation);
            m_manager.GetComponent<Manager>().createdObjs.Add(newGameObject);
            rectTransform.rotation = fan.transform.rotation;
        }
        else
        {
            rectTransform.anchoredPosition = myBox.GetComponent<RectTransform>().anchoredPosition;
            rectTransform.rotation = fan.transform.rotation;
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

        if(fan.gameObject.tag == "Portal" && GameObject.FindGameObjectWithTag("Portal"))
        {
            useable = false;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
        }

        if (fan.gameObject.tag == "PortalExit" && GameObject.FindGameObjectWithTag("PortalExit"))
        {
            useable = false;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
        }
    }

    void LateUpdate()
    {
        if (selected == true)
        {
            float pinchAmount = 0;
            Quaternion desiredRotation = rectTransform.rotation;

            m_manager.GetComponent<RotateTouch>().Calculate();

            if (Mathf.Abs(m_manager.GetComponent<RotateTouch>().pinchDistanceDelta) > 0)
            { // zoom
                pinchAmount = m_manager.GetComponent<RotateTouch>().pinchDistanceDelta;
            }

            if (Mathf.Abs(m_manager.GetComponent<RotateTouch>().turnAngleDelta) > 0)
            { // rotate
                Vector3 rotationDeg = Vector3.zero;
                rotationDeg.z = m_manager.GetComponent<RotateTouch>().turnAngleDelta;
                desiredRotation *= Quaternion.Euler(rotationDeg);
            }


            // not so sure those will work:
            rectTransform.rotation = desiredRotation;
            //transform.position += Vector3.forward * pinchAmount;
        }
    }
}
