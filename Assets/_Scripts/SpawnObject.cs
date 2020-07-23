using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] mySpawns;
    public GameObject[] obstacle;
    public float spawnRate;
    void Start()
    {
        
        Invoke("SpawnMaker", spawnRate);
    }


    void SpawnMaker() 
    {
        //randomly picks objects to spit out for oncoming objects
        int spawnSelector = Random.Range(0, mySpawns.Length);
        int objectSelector = Random.Range(0, obstacle.Length);
        Instantiate(obstacle[objectSelector], mySpawns[spawnSelector].transform.position, mySpawns[spawnSelector].transform.rotation);
       

        Invoke("SpawnMaker", spawnRate);

       
    }

    
}
