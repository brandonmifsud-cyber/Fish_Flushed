using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_Bots : MonoBehaviour
{
    
    public float x, y, z, speed;
    private float offset;
    private Vector3 randomPos;
    private Rigidbody rb;
    private Vector3 lookDir;
  
    
    
    // Start is called before the first frame update
    void Start()
    {
        randomPos = new Vector3(Random.Range(offset, x - offset), Random.Range(offset, y - offset), Random.Range(offset, z - offset));
        lookDir = randomPos - transform.position;
        offset = transform.localScale.x / 2;
        rb = GetComponent<Rigidbody>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == randomPos)
        {
            randomPos = new Vector3(Random.Range(offset, x - offset), Random.Range(offset, y - offset), Random.Range(offset, z - offset));
            lookDir = randomPos - transform.position;
        }
        Vector3 movePos = Vector3.MoveTowards(transform.position, randomPos, speed * Time.deltaTime);
        transform.position = movePos;
        transform.LookAt(transform.position + lookDir);
        
    }
    
    // rotate the position of fish in forward movement


}
