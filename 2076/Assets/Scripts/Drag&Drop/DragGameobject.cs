using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragGameobject : MonoBehaviour
{
    Vector2 touchpos;
    GameObject manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");
    }

    private void OnMouseDrag()
    {
        if (!manager.GetComponent<Manager>().isPlay)
        {
            transform.position = touchpos;
        }
    }

    private void Update()
    {
        touchpos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }
}
