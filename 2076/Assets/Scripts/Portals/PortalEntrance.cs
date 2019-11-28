using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntrance : MonoBehaviour
{
    GameObject Player;
    [Header("Properties")]
    public float TeleportTime = 1.0f;

    [Header("Name Of Objects Related")]
    public GameObject PortalExit;

    public string EntityToTeleport;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find(EntityToTeleport);
    }

    private void Update()
    {
        PortalExit = GameObject.FindGameObjectWithTag("PortalExit");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.SetActive(false);
            StartCoroutine(TeleportPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(TeleportTime);
        Player.SetActive(true);

            Player.transform.position = new Vector2(PortalExit.transform.position.x, PortalExit.transform.position.y);
    }


}
