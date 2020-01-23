using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTutorialText : MonoBehaviour
{
    // Start is called before the first frame update
    string[] m_nameList = 
        {
        "Aim",
        "PlayButtonInfo",
        "RestartButtonInfo",
        "PlatformInfo",
        "ConveyorInfo",
        "CannonInfo",
        "BubbleInfo",
        "PortalInfo",
        "FanInfo" };
    int counter;

    GameObject m_currentText;
    void Start()
    {
        counter = 0;

        m_currentText = gameObject.transform.Find(m_nameList[counter]).gameObject;
       // m_currentText = 
        m_currentText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText()
    {
        m_currentText.SetActive(false);
        counter++;
        Debug.Log(counter);
        if (counter < 9)
        {
            m_currentText = gameObject.transform.Find(m_nameList[counter]).gameObject;
            m_currentText.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
