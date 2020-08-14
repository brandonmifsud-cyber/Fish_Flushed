using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    public int score;
    
    private void Awake()
    {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("Manager");
        if (managers.Length > 1)
        {
            Destroy(gameObject); // keeps current object in scene and destroyes other same tag objects from hierachy
        }
        DontDestroyOnLoad(gameObject);
       
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game_over")
        {
            GameObject scoreText = GameObject.FindGameObjectWithTag("Score");// looking for ui score to get info
            scoreText.GetComponent<Text>().text = "Score " + score.ToString(); // carrys score count to the game over sceen
        }
    }
}
