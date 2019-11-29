using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayandRestart : MonoBehaviour
{
    public GameObject fan;
    public GameObject belt;
    public GameObject bubble;
    public GameObject ball;
    public static bool isPlay = false;

    Create createScript;
    public GameObject gameController;

    Vector3 ballPos;

    private void Start()
    {
        createScript = gameController.GetComponent<Create>();
        ballPos = ball.transform.position;
    }

    public void Play()
    {
        createScript.enableAll();
        ball.GetComponent<Rigidbody2D>().isKinematic = false;
        isPlay = true;
    }

    public void Restart()
    {
        createScript.RemoveAllFromList();
        ball.transform.position = ballPos;

        ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().isKinematic = true;
        isPlay = false;
    }
}
