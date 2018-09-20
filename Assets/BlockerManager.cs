using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerManager : MonoBehaviour {
    public float speed;
    public GameObject[] blocker;
    private int currentObj;
    private bool canPlace;

    // Use this for initialization
    void Start() {
        canPlace = true;
        currentObj = 0;
    }

    void OnTriggerEnter()
    {
        canPlace = false;
    }

    void OnTriggerExit()
    {
        canPlace = true;
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("w"))
        {
            transform.position += Vector3.up * speed;
        }

        if (Input.GetKeyDown("s"))
        {
            transform.position += Vector3.down * speed;
        }

        if (Input.GetKeyDown("a"))
        {
            transform.position += Vector3.left * speed;
        }

        if (Input.GetKeyDown("d"))
        {
            transform.position += Vector3.right * speed;
        }

        if (Input.GetKeyDown("space") && canPlace)
        {
            Instantiate(blocker[currentObj], transform.position, transform.rotation);
            currentObj++;
            if(currentObj >= blocker.Length)
            {
                currentObj = 0;
            }

        }
    }
}
