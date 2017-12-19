using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public float fallTime = 1f;

	public float time;

	public static bool gameOver = false;

	// Use this for initialization
	void Start () {
		time = 0;
		gameOver = false;
		BounceBall.start = false;
	}
	
	// Update is called once per frame
	void Update () {

		//speed up game
		//SpawnPlatforms.timeScale += Time.deltaTime * 0.001f;
	
		if (GameObject.Find ("Ball").transform.position.y <= -0.4f) {
			time += Time.deltaTime;
			gameOver = true;

			if (time >= fallTime) {
				SceneManager.LoadScene ("Level 1");
			}
		}
	}
}
