using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTutorialText : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject m_parent;
    void Start()
    {
        m_parent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.transform.name);
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.transform.name);
        m_parent.GetComponent<ManageTutorialText>().updateText();
    }
}
