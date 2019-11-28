using System.Collections;
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
    public GameObject cannon;
    public GameObject bP;
    public GameObject sP;

    public GameObject ball;

    GameObject objectSelected = null;

    public GameObject eventSystem;

    bool isDragging = false;

    string selected = "";

    Vector3 placement;

    public List<GameObject> createdObjs = new List<GameObject>();

    private void Awake()
    {
        thisCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        bubble.GetComponent<BubbleMovement>().enabled = false;
        bubble.GetComponent<CircleCollider2D>().enabled = false;

        fan.GetComponentInChildren<AreaEffector2D>().enabled = false;
        fan.GetComponent<CapsuleCollider2D>().enabled = false;

        belt.GetComponentInChildren<ConveyorBelt>().enabled = false;
        belt.GetComponentInChildren<CapsuleCollider2D>().enabled = false;

        ball.GetComponent<Rigidbody2D>().isKinematic = true;
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
                objectSelected.transform.position = _get2dMousePosition(); // set the positio
            }
                if (Input.GetMouseButtonDown(0))
                {
                    if(isMouseOverUi() == false)
                    {
                        GameObject created = Instantiate(objectSelected);
                        createdObjs.Add(created);

                    if (created.tag == "Portal")
                        {
                            Destroy(objectSelected);
                            objectSelected = null;
                            objectSelected = portalExit;
                            placePrefab(_get2dMousePosition(), objectSelected);
                        }
                        else
                        {
                            Destroy(objectSelected);
                            objectSelected = null;
                        }
                        return;
                    }                                         
                }
        }
    }

    public void RemoveAllFromList()
    {
        if (createdObjs.Count != 0)
        {
            for (int i = createdObjs.Count - 1; i > -1; i--)
            {
                Destroy(createdObjs[i].gameObject);
                createdObjs.RemoveAt(i);
            }
        }
    }

    public void enableAll()
    {
        if (createdObjs.Count != 0)
        {
            for (int i = createdObjs.Count - 1; i > -1; i--)
            {
                if(createdObjs[i].gameObject.tag == "Fan")
                {
                    createdObjs[i].gameObject.GetComponentInChildren<AreaEffector2D>().enabled = true;
                    createdObjs[i].gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                }

                if (createdObjs[i].gameObject.tag == "Bubble")
                {
                    createdObjs[i].gameObject.GetComponent<BubbleMovement>().enabled = true;
                    createdObjs[i].gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }

                if (createdObjs[i].gameObject.tag == "Belt")
                {
                    createdObjs[i].gameObject.GetComponentInChildren<ConveyorBelt>().enabled = true;
                    createdObjs[i].gameObject.GetComponentInChildren<CapsuleCollider2D>().enabled = true;
                }
            }
        }
    }

    public void createFan()
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost > 0)
        {
            Destroy(objectSelected);

            objectSelected = fan;

            placePrefab(_get2dMousePosition(), objectSelected);

            eventSystem.GetComponent<EventHandling>().updateCost(10);
        }
        
    }

    public void createBelt()
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost > 0)
        {
            Destroy(objectSelected);

            objectSelected = belt;

            placePrefab(_get2dMousePosition(), objectSelected);

            eventSystem.GetComponent<EventHandling>().updateCost(10);
        }
        
    }

    public void createBubble()
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost > 0)
        {
            Destroy(objectSelected);

            objectSelected = bubble;

            placePrefab(_get2dMousePosition(), objectSelected);

            eventSystem.GetComponent<EventHandling>().updateCost(10);
        }
    }

    public void createPortal()
    {
        if (eventSystem.GetComponent<EventHandling>().currentCost > 0)
        {
            Destroy(objectSelected);

            objectSelected = portalEntrance;

            placePrefab(_get2dMousePosition(), objectSelected);

            eventSystem.GetComponent<EventHandling>().updateCost(10);
        }
    }

    public void createCannon()
    {

        Destroy(objectSelected);

        objectSelected = cannon;

        placePrefab(_get2dMousePosition(), objectSelected);

    }


    private bool isMouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void createbP()
    {

        Destroy(objectSelected);

        objectSelected = bP;

        placePrefab(_get2dMousePosition(), objectSelected);

    }

    public void createsP()
    {

        Destroy(objectSelected);

        objectSelected = sP;

        placePrefab(_get2dMousePosition(), objectSelected);

    }

    private Vector2 _get2dMousePosition()
    {
        Vector2 newPos = new Vector2();
        newPos = Input.mousePosition;

        newPos = thisCamera.ScreenToWorldPoint(newPos);
        return newPos;
    }

    void placePrefab(Vector3 location, GameObject obj)
    {
        objectSelected = Instantiate(obj, location,Quaternion.identity);
    }
}
