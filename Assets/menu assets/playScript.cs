﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playScript : MonoBehaviour {

	public void ChangeScene(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}