using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] mySpawns;
    public GameObject[] obstacle;//obstacles spawned in the array
    public float spawnRate, minRate, difficultyRate, obsSpeed, maxSpeed, boostSpeed, boostTimer;
    public List<GameObject> obstacleList = new List<GameObject>();//spawns in the inspector whats in play screen
    public GameObject boost;
    private bool boosting;
   
    void Start()
    {
        // triggers what to spawn
        Invoke("SpawnMaker", spawnRate);
        Invoke("DifficultyIncrease", difficultyRate);
    }

    void Update()
    {
        //what happens when boost has been triggered
        if (boosting == true)
        {
            boostTimer -= Time.deltaTime;
            boostTimer = Mathf.Clamp(boostTimer, 0, 16);//allows up to 16 seconds slow motion
            if (boostTimer == 0)
            {
                boosting = false;
                boost.SetActive(false);//activate slow motion ui in scene
                foreach (GameObject obs in obstacleList)
                {
                    obs.GetComponent<Obstacle>().speed -= boostSpeed;

                }

            }

        }
    }
    void DifficultyIncrease()
    {
        //spawn rate over time will increase
        spawnRate = Mathf.Clamp(spawnRate - .0005f, minRate, 100f);
        obsSpeed = Mathf.Clamp(obsSpeed - .001f, maxSpeed, 100f);


        Invoke("DifficultyIncrease", difficultyRate);
    }

    void SpawnMaker() 
    {
        // how slow the objects will move after boost trigger active
        float tempSpeed = obsSpeed;
        if (boosting == true)
        {
            tempSpeed += boostSpeed;
        }
        //randomly picks objects to spit out for oncoming objects
        int spawnSelector = Random.Range(0, mySpawns.Length);//actively random;y picks objects in inspector panel from spawn points in game
        int objectSelector = Random.Range(0, obstacle.Length);
        GameObject obs = Instantiate(obstacle[objectSelector], mySpawns[spawnSelector].transform.position, mySpawns[spawnSelector].transform.rotation);
        obstacleList.Add(obs); // shows in inpsector panel objects
        obs.GetComponent<Obstacle>().speed = tempSpeed;
        obs.GetComponent<Obstacle>().so = this;


        Invoke("SpawnMaker", spawnRate);

       
    }

    public void Booster()
    {
        // when boost active will slow by 8secs
        boosting = true;
        boostTimer += 8;
        StartCoroutine(Pulse()); // activate pulse function

        foreach (GameObject obs in obstacleList)
        {
            obs.GetComponent<Obstacle>().speed = obsSpeed + boostSpeed;

        }
    }

    IEnumerator Pulse()// makes the slow motion flash on and off
    {
        if (boosting == true)
        {
            // controls the delays of on and off for slow motion title
            boost.SetActive(true);
            yield return new WaitForSeconds(.5f);//stays active for 1/2 sec
            boost.SetActive(false);
            yield return new WaitForSeconds(.25f);// waits 1/4 of sec to come back on
            if (boosting == true)
            {
                StartCoroutine(Pulse());
            }
        }

    }
    
}
