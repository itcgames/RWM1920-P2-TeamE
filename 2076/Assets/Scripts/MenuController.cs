using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void options()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
