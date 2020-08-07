using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseScreen;
    private bool paused;

    //loads menu back and fourth between play pause resume mainmenu
    private void Start()
    {
        Pause();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        paused = false;
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        paused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0;

    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
}
