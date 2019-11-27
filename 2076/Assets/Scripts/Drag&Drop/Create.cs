﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    Camera thisCamera;

    [Header("Objects")]
    public GameObject fan;
    public GameObject belt;
    public GameObject bubble;
    public GameObject portalEntrance;
    public GameObject portalExit;

    GameObject created;

    GameObject objectSelected = null;

    bool isDragging = false;

    string selected = "";

    Vector3 placement;

    bool clickedB;



    private void Awake()
    {
        thisCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        //bubble.GetComponent<BubbleMovement>().enabled = false;
        //bubble.GetComponent<CircleCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
            if (objectSelected != null)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    objectSelected.transform.Rotate(Vector3.forward, 1);
                }

                if (Input.GetKey(KeyCode.RightArrow))
                {
                    objectSelected.transform.Rotate(Vector3.back, 1);
                }

                // if the mouse is not being pressed 
                if (!Input.GetMouseButton(0))
                {
                    objectSelected.transform.position = _get3dMousePosition(); // set the positio
                }
                if (isMouseOverUi() == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        created = Instantiate(objectSelected);
                        if (created.tag == "Portal")
                        {
                            Destroy(objectSelected);
                            objectSelected = null;
                            Debug.Log("What do I do now");
                            objectSelected = portalExit;
                            placePrefab(_get3dMousePosition(), objectSelected);
                        }
                        else
                        {
                            Destroy(objectSelected);
                            objectSelected = null;
                        }
                    }
                }

            }
        
    }



    public void createFan()
    {

            Destroy(objectSelected);
        
        objectSelected = fan;
    
            placePrefab(_get3dMousePosition(), objectSelected);
        
    }

    public void createBelt()
    {
   
            Destroy(objectSelected);
        
        objectSelected = belt;
    
            placePrefab(_get3dMousePosition(), objectSelected);
        
    }

    public void createBubble()
    {
      
            Destroy(objectSelected);
        
        objectSelected = bubble;
      
            placePrefab(_get3dMousePosition(), objectSelected);
        
    }
    public void createPortal()
    {
      
            Destroy(objectSelected);
        
        objectSelected = portalEntrance;
     
            placePrefab(_get3dMousePosition(), objectSelected);
        
    }


    private bool isMouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    private Vector3 _get3dMousePosition()
    {
        Vector3 newPos = new Vector3();
        newPos = Input.mousePosition;
        newPos.z = 10;

        newPos = thisCamera.ScreenToWorldPoint(newPos);
        return newPos;
    }

    void placePrefab(Vector3 location, GameObject obj)
    {
        objectSelected = Instantiate(obj, location,Quaternion.identity);
    }
}
