using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour
{
    float speed = 2.0f;
    public bool accelerated = false;
    public bool decelerate = false;

    public Vector2 velocity = new Vector2(0,0);

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (accelerated == false && decelerate == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (velocity.x > -1.0f)
                {
                    velocity.x -= 1.0f;
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (velocity.x < 1.0f)
                {
                    velocity.x += 1.0f;
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false)
            {
                velocity.x = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (velocity.y < 1.0f)
                {
                    velocity.y += 1.0f;
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (velocity.y > -1.0f)
                {
                    velocity.y += -1.0f;
                }
            }

            if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false)
            {
                velocity.y = 0;
            }
        }
        rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        decelerate = false;
    }
}
