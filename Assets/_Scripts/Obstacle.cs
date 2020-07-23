using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed, killz;
   
    
    void Start()
    {
        
    }

    void Update()
    {
        // destroys the Game object at set location after camera
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (transform.position.z <= killz)
        {
            Destroy(gameObject);
        }
    }
}
