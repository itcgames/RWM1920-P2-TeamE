using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public void playGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void options()
    {
        menu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void help()
    {
        menu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void back()
    {
        menu.SetActive(true);
        optionsMenu.SetActive(false);
        helpMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
