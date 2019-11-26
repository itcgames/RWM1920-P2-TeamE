using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAcceleration : MonoBehaviour
{
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {
            controller.GetComponent<Acceleration>().accelerate = false;
            controller.GetComponent<Acceleration>().decelerate = true;
    }
}
