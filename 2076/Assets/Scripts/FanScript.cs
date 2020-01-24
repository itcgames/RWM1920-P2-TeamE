using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    public GameObject m_obj;
    public GameObject Explosion;
    float criticalVelocity = 9;
    int damageCount = 3;

    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((m_obj.GetComponent<Rigidbody2D>().velocity.y * -1) > criticalVelocity)
        {
            damageCount--;
            Debug.Log(damageCount);
            if (damageCount == 0)
            {
                Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }
    }

}
