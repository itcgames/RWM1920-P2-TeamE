using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Vector3 forward = collision.gameObject.transform.TransformDirection(Vector3.forward);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(forward * 10, ForceMode2D.Impulse);
        }
    }
}
