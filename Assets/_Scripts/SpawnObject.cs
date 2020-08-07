using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] mySpawns;
    public GameObject[] obstacle;
    public float spawnRate, minRate, difficultyRate, obsSpeed, maxSpeed, boostSpeed, boostTimer;
    public List<GameObject> obstacleList = new List<GameObject>();
    public GameObject boost;
    private bool boosting;
   
    void Start()
    {
        
        Invoke("SpawnMaker", spawnRate);
        Invoke("DifficultyIncrease", difficultyRate);
    }

    void Update()
    {
        if (boosting == true)
        {
            boostTimer -= Time.deltaTime;
            boostTimer = Mathf.Clamp(boostTimer, 0, 16);
            if (boostTimer == 0)
            {
                boosting = false;
                foreach (GameObject obs in obstacleList)
                {
                    obs.GetComponent<Obstacle>().speed -= boostSpeed;

                }

            }

        }
    }
    void DifficultyIncrease()
    {
        spawnRate = Mathf.Clamp(spawnRate - .0005f, minRate, 100f);
        obsSpeed = Mathf.Clamp(obsSpeed - .001f, maxSpeed, 100f);


        Invoke("DifficultyIncrease", difficultyRate);
    }

    void SpawnMaker() 
    {

        float tempSpeed = obsSpeed;
        if (boosting == true)
        {
            tempSpeed += boostSpeed;
            boost.SetActive(true);
        }
        else
        {
            boost.SetActive(false);
        }
        //randomly picks objects to spit out for oncoming objects
        int spawnSelector = Random.Range(0, mySpawns.Length);
        int objectSelector = Random.Range(0, obstacle.Length);
        GameObject obs = Instantiate(obstacle[objectSelector], mySpawns[spawnSelector].transform.position, mySpawns[spawnSelector].transform.rotation);
        obstacleList.Add(obs);
        obs.GetComponent<Obstacle>().speed = tempSpeed;
        obs.GetComponent<Obstacle>().so = this;


        Invoke("SpawnMaker", spawnRate);

       
    }

    public void Booster()
    {
        boosting = true;
        boostTimer += 8;

        foreach(GameObject obs in obstacleList)
        {
            obs.GetComponent<Obstacle>().speed = obsSpeed + boostSpeed;

        }
    }

    
    
}
