using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    private GameObject player;

    float angle;
    float speed;
    float baseSpeed;

    public bool accelerate = false;
    public bool decelerate = false;

    public GameObject m_slider;
    float angleToSlider;
    float angleToOriginalPos;
    float additionalSpeed;

    float distance = 0;

    Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        angle = transform.rotation.eulerAngles.z - 90;
        speed = 0.75f;
        baseSpeed = speed;
        originalPosition = m_slider.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (accelerate == true)
        {
            Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * speed, Mathf.Sin(Mathf.Deg2Rad * angle) * speed);

            player.GetComponent<Rigidbody2D>().velocity += newSpeed;
        }

        //if (decelerate == true)
        //{
        //    Vector2 newSpeed = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle) * -speed);

        //    player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, player.GetComponent<Rigidbody2D>().velocity.y + newSpeed.y);
        //}

        if (m_slider.GetComponent<CheckForClickAccel>().m_drag == true)
        {
            moveSlider();
        }
    }

    public void correctVelocity()
    {
        float mag = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle) * mag, Mathf.Sin(Mathf.Deg2Rad * angle) * mag);
    }

    private void moveSlider()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        angleToSlider = Mathf.Round(Mathf.Rad2Deg * Mathf.Atan2(m_slider.transform.position.y - mousePos.y, m_slider.transform.position.x - mousePos.x) - transform.rotation.eulerAngles.z);
        
        distance =Mathf.Round((1000 * Vector3.Distance(originalPosition, m_slider.transform.position)) / 7) / 100;

        if(angleToSlider < -180)
        {
            angleToSlider = angleToSlider + 360;
        }

        angleToOriginalPos = Mathf.Round(Mathf.Rad2Deg * Mathf.Atan2(m_slider.transform.position.y - originalPosition.y, m_slider.transform.position.x - originalPosition.x) - transform.rotation.eulerAngles.z);
        if (angleToOriginalPos < -180)
        {
            angleToOriginalPos = angleToOriginalPos + 360;
        }

        if(angleToOriginalPos == 90)
        {
            distance = distance * -1;
        }
        //Debug.Log(angleToOriginalPos);

        if ((angleToSlider < 160 && angleToSlider > 20) || (angleToSlider > -160 && angleToSlider < -20))
        {
            if (angleToSlider > -160 && angleToSlider < -20 && distance > -1)
            {
                m_slider.transform.Translate(new Vector3(0.05f, 0, 0));
            }
            else if(angleToSlider < 160 && angleToSlider > 20 && distance < 1)
            {
                m_slider.transform.Translate(new Vector3(-0.05f, 0, 0));
            }
            additionalSpeed = distance / 2;
            speed = baseSpeed + additionalSpeed;
        }
    }

    public void setObject(GameObject acceleratedObject)
    {
        Debug.Log(12212);
        player = acceleratedObject;
    }
}
