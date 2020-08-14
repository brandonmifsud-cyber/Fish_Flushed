using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed, killz;
    public SpawnObject so;
   

    void Update()
    {
        // destroys the Game object at set location after camera
        transform.Translate(0, 0, speed * Time.deltaTime);// moves on the z axis towards the player
        if (transform.position.z <= killz)
        {
            so.obstacleList.Remove(gameObject);
            Destroy(gameObject);//destroy the fish character
        }
    }
}
