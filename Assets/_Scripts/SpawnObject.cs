using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] mySpawns;
    public GameObject[] obstacle;
    public float spawnRate, minRate, difficultyRate, obsSpeed, maxSpeed;

   
    void Start()
    {
        
        Invoke("SpawnMaker", spawnRate);
        Invoke("DifficultyIncrease", difficultyRate);
    }

    void DifficultyIncrease()
    {
        spawnRate = Mathf.Clamp(spawnRate - .01f, minRate, 100f);
        obsSpeed = Mathf.Clamp(obsSpeed - .1f, maxSpeed, 100f);


        Invoke("DifficultyIncrease", difficultyRate);
        print(spawnRate);
        print(obsSpeed);
    }

    void SpawnMaker() 
    {
        //randomly picks objects to spit out for oncoming objects
        int spawnSelector = Random.Range(0, mySpawns.Length);
        int objectSelector = Random.Range(0, obstacle.Length);
        GameObject obs = Instantiate(obstacle[objectSelector], mySpawns[spawnSelector].transform.position, mySpawns[spawnSelector].transform.rotation);
        obs.GetComponent<Obstacle>().speed = obsSpeed;
       

        Invoke("SpawnMaker", spawnRate);

       
    }

    
}
