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

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
        eventHandler = GameObject.Find("EventSystem");
    }

    private void OnMouseDrag()
    {
        if (!manager.GetComponent<Manager>().isPlay)
        {
            if (count == 0)
            {
                intialPos = transform.position;
                count++;
            }
            sort = gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
            transform.position = touchpos;
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
    }

    private void Update()
    {
        touchpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
