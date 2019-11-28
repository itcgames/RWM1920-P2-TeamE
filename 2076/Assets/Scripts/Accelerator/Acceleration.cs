using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public GameObject player;
    private Animator anim;

    float angle;
    float speed;

    public bool accelerate = false;
    public bool decelerate = false;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.rotation.eulerAngles.z - 90;
        speed = 0.5f;
        anim = GetComponent<Animator>();
        Debug.Log(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if(accelerate == true)
        {
            anim.SetBool("Fire", true);
            Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * speed, Mathf.Sin(Mathf.Deg2Rad * angle) * speed);

            player.GetComponent<Rigidbody2D>().velocity += newSpeed;
        }

        if (decelerate == true)
        {
            Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle) * -speed);

            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y + newSpeed.y);
        }
    }

    public void correctVelocity()
    {
        float mag = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        Debug.Log(mag);
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * mag, Mathf.Sin(Mathf.Deg2Rad * angle) * mag);
        Debug.Log(player.GetComponent<Rigidbody2D>().velocity);
    }
}
