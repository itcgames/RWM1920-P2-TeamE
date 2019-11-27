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
        rb2D.velocity = new Vector2(10.0f, 0);
    }

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.MovePosition(rb2D.position + rb2D.velocity * Time.fixedDeltaTime);
        
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        decelerate = false;
    }
}
