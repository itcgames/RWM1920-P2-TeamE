using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragGameobject : MonoBehaviour
{
    Vector2 touchpos;
    Vector2 intialPos;
    int count = 0;
    GameObject manager;
    GameObject eventHandler;
    private string sort;
    GameObject portalEntrance;
    bool selected = false;


    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        eventHandler = GameObject.Find("EventSystem");
        portalEntrance = GameObject.FindGameObjectWithTag("Portal");
    }

    private void OnMouseDrag()
    {
        selected = true;
        if (!manager.GetComponent<Manager>().isPlay)
        {
            if (count == 0)
            {
                intialPos = transform.position;
                count++;
            }
            sort = gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";

            if(tag == "PortalExit")
            {
                Debug.Log(Vector2.Distance(transform.position, portalEntrance.transform.position));
                if(Vector2.Distance(transform.position, portalEntrance.transform.position) >= 10.0f )
                {
                    transform.position = transform.position;
                }
                else
                {
                    transform.position = touchpos;
                }
            }
            else
            {
                transform.position = touchpos;
            }

        }
    }

    private void OnMouseUp()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(touchpos, 1);
        for (int i = 0; i< hit.Length; i++)
        {
            if(hit[i].gameObject.name == "Bin")
            {
                if(gameObject.tag == "Fan")
                {
                    eventHandler.GetComponent<EventHandling>().refund(30);
                }
                if (gameObject.tag == "Portal")
                {
                    eventHandler.GetComponent<EventHandling>().refund(110);
                }
                if (gameObject.tag == "Platform")
                {
                    eventHandler.GetComponent<EventHandling>().refund(10);
                }
                if (gameObject.tag == "Bubble")
                {
                    eventHandler.GetComponent<EventHandling>().refund(20);
                }
                if (gameObject.tag != "Fan" && gameObject.tag != "Portal" && gameObject.tag != "Platform" && gameObject.tag != "Bubble")
                {
                    eventHandler.GetComponent<EventHandling>().refund(20);
                }
        Destroy(gameObject);
            }
            if(hit[i].gameObject.tag == "HUD")
            {
               gameObject.transform.position = intialPos;
            }

        }
        gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sort;
        count = 0;
        selected = false;
    }

    private void Update()
    {
        touchpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

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
            Quaternion desiredRotation = gameObject.transform.rotation;

            manager.GetComponent<RotateTouch>().Calculate();

            if (Mathf.Abs(manager.GetComponent<RotateTouch>().pinchDistanceDelta) > 0)
            { // zoom
                pinchAmount = manager.GetComponent<RotateTouch>().pinchDistanceDelta;
            }

            if (Mathf.Abs(manager.GetComponent<RotateTouch>().turnAngleDelta) > 0)
            { // rotate
                Vector3 rotationDeg = Vector3.zero;
                rotationDeg.z = manager.GetComponent<RotateTouch>().turnAngleDelta;
                desiredRotation *= Quaternion.Euler(rotationDeg);
            }


            // not so sure those will work:
            gameObject.transform.rotation = desiredRotation;
            //transform.position += Vector3.forward * pinchAmount;
        }
    }
}
