using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DragIcon;
    public GameObject RotateAround;

    private float originalAngle;
    private float currentAngle;

    void Start()
    {
        originalAngle = Mathf.Round(transform.rotation.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (DragIcon.GetComponent<CheckForClickAngle>().m_drag == true)
        {
            currentAngle = Mathf.Round(transform.rotation.eulerAngles.z);

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(RotateAround.transform.position.x - mousePos.x, RotateAround.transform.position.y - mousePos.y);

            Debug.Log(targetAngle + " " + transform.rotation.eulerAngles.z);

            if (targetAngle < 0)
            {
                targetAngle = targetAngle * -1;
            }
            else
            {
                targetAngle = 360 - targetAngle;
            }

            //Debug.Log(targetAngle + " " + transform.rotation.eulerAngles.z);

            float angleDifferenceForward = targetAngle - transform.rotation.eulerAngles.z;
            float angleDifferenceBack = transform.rotation.eulerAngles.z - targetAngle;

            if (angleDifferenceForward < 0)
            {
                angleDifferenceForward = 360 + angleDifferenceForward;
            }
            else if (angleDifferenceBack < 0)
            {
                angleDifferenceBack = 360 + angleDifferenceBack;
            }

            Debug.Log(angleDifferenceForward + " " + angleDifferenceBack);
            // Debug.Log(RotateAround.transform.position +  transform.position  - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,100)));
            //Debug.Log(RotateAround.transform.position + " " + Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)) + " " + Mathf.Round(targetAngle));
            //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)));

            if (Mathf.Round(transform.rotation.eulerAngles.z) != Mathf.Round(targetAngle))
            {
                if (angleDifferenceForward < angleDifferenceBack
                    &&
                    currentAngle != originalAngle + 30)
                {
                    transform.RotateAround(
                        RotateAround.transform.position,
                        Vector3.forward,
                        10 * Time.deltaTime);
                }
                else if (
                    angleDifferenceForward > angleDifferenceBack
                    &&
                    currentAngle != originalAngle - 30)
                {
                    transform.RotateAround(
                        RotateAround.transform.position,
                        Vector3.back,
                        10 * Time.deltaTime);
                }
            }
        }
    }
}
