using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAcceleration : MonoBehaviour
{
    public GameObject controller;
    GameObject startObject;
    // Start is called before the first frame update
    void Start()
    {
        startObject = GameObject.Find("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
       controller.GetComponent<Acceleration>().accelerate = false;
        //controller.GetComponent<Acceleration>().decelerate = true;
        startObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
}
