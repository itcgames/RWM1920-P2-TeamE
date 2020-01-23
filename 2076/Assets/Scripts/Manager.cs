using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject ball;
    public GameObject eventSystem;

    public List<GameObject> createdObjs = new List<GameObject>();
    Vector3 ballPos;
    public bool isPlay = false;

    // Start is called before the first frame update
    void Start()
    {

        ball.GetComponent<Rigidbody2D>().isKinematic = true;

        ballPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlay)
        {
            eventSystem.GetComponent<EventHandling>().timer();
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
                if (createdObjs[i].gameObject.tag == "Fan")
                {
                    createdObjs[i].gameObject.GetComponentInChildren<AreaEffector2D>().enabled = true;
                    createdObjs[i].gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
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
                if (createdObjs[i].gameObject.tag == "Cannon")
                {
                    createdObjs[i].GetComponentInChildren<BoxCollider2D>().enabled = true;
                    createdObjs[i].GetComponentInChildren<BoxCollider2D>().isTrigger = false;
                }
            }
        }
    }

    public void Play()
    {
        isPlay = true;
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        enableAll();
    }
    public void Restart()
    {

        isPlay = false;
        ball.transform.position = ballPos;
        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        eventSystem.GetComponent<EventHandling>().resetCost();
        RemoveAllFromList();
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
