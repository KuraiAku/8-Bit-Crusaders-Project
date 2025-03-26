using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUITING!");
        Application.Quit();
    }

    public GameObject optionsPanel;
    public GameObject optionsButton;
    private bool isPaused = false;

    public void OpenOptions()
    {
        optionsButton.SetActive(false);
        optionsPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    public void CloseOptions()
    {
        optionsButton.SetActive(true);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BackToGame()
    {
        CloseOptions();
        isPaused = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                CloseOptions();
            }
            else
            {
                OpenOptions();
            }
        }
    }
}
