using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void PlayApp()
    {
        SceneManager.LoadScene("Level01");
    }

    public void AppQuit()
    {
        Application.Quit();
    }

    public void AppMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
