using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuumManager : MonoBehaviour {
    public float startDelay;
    public float speed;
    public Rigidbody rb;
    public float gameSpeedInc;
    public float maxGameSpeed;
    private bool collided;
	// Use this for initialization
	void Start () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "blockerSpawn")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            collided = true;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ |
                RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                RigidbodyConstraints.FreezePositionZ;

        }
        
    }

    // Update is called once per frame
    void FixedUpdate () {
		if (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
        } else if (!collided)
        {
            if(speed < maxGameSpeed)
            {
                speed += gameSpeedInc * Time.deltaTime;
            }
            
            transform.position += Vector3.up * speed;
        }
        
	}
}
