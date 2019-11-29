using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    public Button portalButton;
    public Button fanButton;
    public Button beltButton;
    public Button bubbleButton;
    public Button platButton;
    public Button bigPlatButton;
    public Button canonButton;

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

        portalButton.interactable = true;
        fanButton.interactable = true;
        beltButton.interactable = true;
        bubbleButton.interactable = true;
        platButton.interactable = true;
        bigPlatButton.interactable = true;
        canonButton.interactable = true;

        isPlay = false;


    }
}
