using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {
    
    public float speed;
    public Text CountText;
    public Text winText;
    public Text ScoreText;
    private Rigidbody rb;
    private int count;
    private int score;
    void Start ()
    {
        rb=GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    private void SetCountText()
    {
        throw new NotImplementedException();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
       
       rb.AddForce (movement * speed); 
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            score = score + 1;
            SetCountText ();
            SetScoreText ();
        }  
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1; 
            score = score - 1; 
            SetCountText();
            SetScoreText();
   
    }
    void SetCountText ()
    {
        CountText.text = "Count: " + count.ToString ();
        if (count == 12)
        {
            transform.position = new Vector3(25,transform.position.y,-1);
        }
    }
     void SetScoreText ()
    {
        ScoreText.text = "Score: " + score.ToString ();
        if (score >= 20)    
        {
            winText.text = "You Win!";
        }
    }

    
    
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}