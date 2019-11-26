using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    public GameObject player;

    float angle;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.rotation.eulerAngles.z - 90;
        speed = 2.0f;
        Debug.Log(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerValues>().accelerated == true)
        {
            Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * speed, Mathf.Sin(Mathf.Deg2Rad * angle) * speed);

            player.GetComponent<PlayerValues>().velocity += newSpeed;
        }

        if (player.GetComponent<PlayerValues>().decelerate == true)
        {
            Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle) * -speed);

            player.GetComponent<PlayerValues>().velocity.y += newSpeed.y;
        }
    }

    public void correctVelocity()
    {
        float mag = player.GetComponent<PlayerValues>().velocity.magnitude;
        player.GetComponent<PlayerValues>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * mag, Mathf.Sin(Mathf.Deg2Rad * angle) * mag);
    }
}
