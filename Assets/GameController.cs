using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject player;
    public GameObject camera;
    public GameObject gameOverText;
    public float failOffset;


	// Use this for initialization
	void Start () {
        gameOverText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.y < camera.transform.position.y + failOffset)
        {
            gameOverText.SetActive(true);
        }
	}
}
