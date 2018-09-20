using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMovement : MonoBehaviour {
    public float speed;
    public float jumpForce;
    public Rigidbody rb;
    private bool isGrounded;
    private float oldHeight;

	// Use this for initialization
	void Start () {
        oldHeight = transform.position.y;
	}

    private void Update()
    {
        if(oldHeight == transform.position.y)
        {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

        oldHeight = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (Input.GetKey("left"))
        {
            transform.position += Vector3.left * speed;
        }

        if (Input.GetKey("right"))
        {
            transform.position += Vector3.right * speed;
        }

        if(Input.GetKeyDown("up") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
	}


}
