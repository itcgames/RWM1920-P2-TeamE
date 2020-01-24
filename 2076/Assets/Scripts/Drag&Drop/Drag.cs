using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] public Canvas canv;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public GameObject current;
    public GameObject myBox;

    public GameObject eventSystem;
    public int COST = 0;
    public bool useable = true;

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

    private void Start()
    {
        if (current.gameObject.tag == "PortalExit")
        {
            useable = false;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
        }
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
        if (useable == true && m_manager.GetComponent<Manager>().isPlay == false)
        {
            canvasGroup.blocksRaycasts = true; canvasGroup.alpha = 1.0f; rectTransform.anchoredPosition = myBox.GetComponent<RectTransform>().anchoredPosition;
            Vector3 newPos; newPos = Camera.main.ScreenToWorldPoint(eventData.position); newPos.z = 0;
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (SceneManager.GetActiveScene().name != "Custom")
                {
                    if (current.gameObject.tag != "PortalExit")
                    {
                        if (eventSystem.GetComponent<EventHandling>().currentCost >= COST)
                        { eventSystem.GetComponent<EventHandling>().updateCost(COST); }
                    }
                }
                GameObject newGameObject = Instantiate(current, newPos, rectTransform.rotation); m_manager.GetComponent<Manager>().createdObjs.Add(newGameObject);
            }
            rectTransform.rotation = Quaternion.identity; selected = false;
        }
        else { selected = false; rectTransform.anchoredPosition = myBox.GetComponent<RectTransform>().anchoredPosition; rectTransform.rotation = Quaternion.identity; }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private void Update()
    {
        // Turns object off if you dont have enough
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

        // if the current object has a tag of portal && if there are any gameobjects of portal in the scene
        // else if the current object is portal exit turn it off
        if(current.gameObject.tag == "Portal" && GameObject.FindGameObjectWithTag("Portal"))
        {
            useable = false;
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
        }

        if (current.gameObject.tag == "PortalExit")
        {
            if (GameObject.FindGameObjectWithTag("Portal"))
            {
                useable = true;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
            }
            else
            {
                useable = false;
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0.5f);
            }
        }

        if(m_manager.GetComponent<Manager>().isPlay == false)
        {
            DragGameObject();
        }

        if (selected == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(Vector3.forward, -50 * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(Vector3.forward, 50 * Time.deltaTime);
            }
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

    private void DragGameObject()
    {
        //if (!EventSystem.current.IsPointerOverGameObject())
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Vector2 touchpos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0/*Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0*/));
        //        Collider[] hit = Physics.OverlapSphere(touchpos, 0);

        //        for (int i = 0; i < hit.Length; i++)
        //        {

        //            if (hit[i] != null)
        //            {
        //                Debug.Log(hit[i].gameObject.name);
        //                //hit.gameObject.transform.position = touchpos;
        //            }
        //        }
        //    }
        //}
    }

    public void OnEndDrags()
    {
            canvasGroup.blocksRaycasts = true; canvasGroup.alpha = 1.0f;
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                GameObject newGameObject = Instantiate(current, newPos, rectTransform.rotation); m_manager.GetComponent<Manager>().createdObjs.Add(newGameObject);
            }
    }
}
