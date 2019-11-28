using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlow : MonoBehaviour
{
    public Vector3 bubbleSize;
    public Vector3 blowSpeed;

    // Update is called once per frame
    void Update()
    {

        //blowing up the bubble
        if (transform.localScale != bubbleSize)
        {
            transform.localScale += blowSpeed;
        }
    }
}
