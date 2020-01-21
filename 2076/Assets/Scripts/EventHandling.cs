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

    public ParticleSystem particles;
    Vector3 position = new Vector3(-25, 10, 1);

    void Start()
    {
        gameOverTime = 5.0f;
        gameTimer = 0.0f;
        m_timeText.text = (Mathf.Ceil(gameTimer)).ToString();

        m_costText.text = currentCost.ToString();
    }

    // Update is called once per frame
    public void timer()
    {

        //if (PlayandRestart.isPlay)
        //{
            if (m_endPoint.GetComponent<GameOver>().getGameOver() == true)
            {
                if (gameOverTime == 5.0f)
                {
                    m_endPanel.SetActive(true);
                    Instantiate(particles);
                }
                if (gameOverTime <= 0)
                {
                    SceneManager.LoadScene("MainMenu");
                }
                gameOverTime -= Time.deltaTime;
            }


            if (gameTimer >= 0)
            {
                m_timeText.text = (Mathf.Ceil(gameTimer)).ToString();
                Debug.Log(m_timeText.text);
                gameTimer += Time.deltaTime;
            }
        // }
    }

    public void updateCost(float t_cost)
    {
        currentCost -= t_cost;
        m_costText.text = currentCost.ToString();
    }

    public void resetCost()
    {
        currentCost = 200;
        gameTimer = 0.0f;
        m_costText.text = currentCost.ToString();
        m_timeText.text = (Mathf.Ceil(gameTimer)).ToString();
    }

    public void resetG()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
