using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EventHandling : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_endPoint;
    public GameObject m_endPanel;
    public TextMeshProUGUI m_timeText;
    public TextMeshProUGUI m_costText;

    float gameOverTime;
    float gameTimer;

    public float currentCost = 200;

    void Start()
    {
        gameOverTime = 5.0f;
        gameTimer = 60.0f;

        m_costText.text = currentCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
 

        if(m_endPoint.GetComponent<GameOver>().getGameOver() == true || gameTimer < 0)
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

        if (gameTimer > 0)
        {
            m_timeText.text = (Mathf.Ceil(gameTimer)).ToString();
            Debug.Log(m_timeText.text);
            gameTimer -= Time.deltaTime;
        }
    }

    public void updateCost(float t_cost)
    {
        currentCost -= t_cost;
        m_costText.text = currentCost.ToString();
    }
}
