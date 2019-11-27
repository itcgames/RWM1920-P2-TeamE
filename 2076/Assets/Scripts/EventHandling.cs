using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventHandling : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_endPoint;
    public GameObject m_endPanel;

    float gameOverTime;

    void Start()
    {
        gameOverTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_endPoint.GetComponent<GameOver>().getGameOver() == true)
        {
            if (gameOverTime == 5.0f)
            {
                m_endPanel.SetActive(true);
            }
            if (gameOverTime <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }

            gameOverTime -= Time.deltaTime;
        }
    }
}
