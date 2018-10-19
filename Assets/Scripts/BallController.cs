using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float jumpHeight;
    public float speed;

    private Rigidbody rb;
    private bool isInAir;

	void Start () {
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
	}
}
