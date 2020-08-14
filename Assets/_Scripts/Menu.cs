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
        Pause();// activates pause function
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();// activate resume funtcion
            }
            else 
            {
                Pause();// activates pause function
            }
            
        }
    }

    public void Resume() // plays the game from time paused
    {
        paused = false;
        pauseScreen.SetActive(false);
        // to resaume play at normal time
        Time.timeScale = 1;
    }

    public void Pause()//  pause function
    {
        paused = true;
        pauseScreen.SetActive(true);
        Time.timeScale = 0; // stops time in game play

    }

    public void LoadScene(string sceneName) // loads scene set in inspector
    {
        Time.timeScale = 1; // sets time back to running speed of computer     ;)
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
