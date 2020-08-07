using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class FishMovement : MonoBehaviour
{
    //variables used in inspector
    public float speed, lookForward;
    private Rigidbody rb;
   
    private Vector3 movement;
    private AudioClip effect;


    public Text countText, countText2, totalScore;
    public string replay;
    public SpawnObject spawn;
    public AudioSource bubbleEffect;
    public AudioClip bubble;
    int count;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        //links to the counter in game
        SetCountText();
        totalScore.text = "";
        // plays audio file
        bubbleEffect = GetComponent<AudioSource>();
        effect = bubble;
        bubbleEffect.Play();

    }


    void FixedUpdate()
    {
        //movement of fish
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movement = new Vector3(x, y, 0) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
        //rotation of fish(makes look like swimming left to right) more smooth too
        Vector3 lookPos = transform.position + movement + Vector3.forward * lookForward;
        transform.LookAt(lookPos,Vector3.up);
    }

    void OnCollisionEnter(Collision col)
    {
        // counter for pickups collected
        if (col.gameObject.CompareTag("Pick Up"))
        {
            count = count + 1;
            SetCountText();
            spawn.obstacleList.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
        //triggers the boost effect
        else if (col.gameObject.CompareTag("Booster"))
        {
            spawn.Booster();
            spawn.obstacleList.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
        //destroy game object on coliision and reload scene
        else if  (col.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);

            //reloads scene currently0
            SceneManager.LoadScene(sceneName: replay);
        }

    }
    void SetCountText()
    {
        //diplays the counter for pickups collected
        countText.text = "COUNT: " + count.ToString();
        countText2.text = "COUNT: " + count.ToString();

    }


}
