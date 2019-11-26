using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public ParticleSystem dust;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.magnitude > 0)
        {
            dust.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y - 0.3f, transform.position.z);
            dust.Play();
            transform.hasChanged = false;
        }
    }
}
