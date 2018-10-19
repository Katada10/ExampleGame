using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public float jumpHeight;

    private Rigidbody rb;
    private bool isInAir;

	void Start () {
        rb = GetComponent<Rigidbody>();
        isInAir = false;
    }
	
    void OnCollisionExit(Collision col)
    {
        isInAir = true;
    }

    void OnCollisionEnter(Collision col)
    {
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
	}
}
