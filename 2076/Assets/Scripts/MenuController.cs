using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public GameObject helpMenu;
    public GameObject levelSelect;

    public void levelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void levelThree()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void custom()
    {
        SceneManager.LoadScene("Custom");
    }

    public void selectLevel()
    {
        menu.SetActive(false);
        levelSelect.SetActive(true);
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
        levelSelect.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
