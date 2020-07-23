using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
   
    private Vector3 movement;
    public Text countText, totalScore;
    public string replay;
    public GameObject ps;


    int count;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        totalScore.text = "";
    }


    void Update()
    {
        //movement of fish
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        movement = new Vector3(x, y, 0) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Pick Up"))
        {
           col.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (col.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);

            //reloads scene currently0
            SceneManager.LoadScene(sceneName: replay);
        }

    }
    void SetCountText()
    {
        //need to fix "add a popup when game gets destroyed
        countText.text = "Count: " + count.ToString();
       
    }
}
