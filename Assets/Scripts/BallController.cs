using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float jumpHeight;
    public float speed;

    private Rigidbody rb;
    private bool isInAir;


	void Start () {
        Game.isGameOver = false;
        rb = GetComponent<Rigidbody>();
        isInAir = false;
    }
	
    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.name == "Floor")
            isInAir = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Floor")
            isInAir = false;   

        if(col.gameObject.name.Contains("Obstacle"))
        {
            Game.isGameOver = true;
        }    
    }


    void EndGame()
    {
        jumpHeight = 0;
        speed = 0;
    }

	void FixedUpdate () {
        if (!isInAir)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(0, jumpHeight, 0);
        
            }
        }

        var h = Input.GetAxisRaw("Horizontal");
        rb.velocity += Vector3.right * h * speed * Time.deltaTime;

        if(Game.isGameOver)
        {
            EndGame();
        }
	}
}
