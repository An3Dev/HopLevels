using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour {

	GameObject prefab;

	GameObject platform;

	long totalPlatformsInstantiated = 0;

	long currentPlatformClones = 0;

	public float distanceBetweenPlatforms = 5;

	public float timeScale;

	public float minRange, maxRange;

	float time;
	long totalPlatformsDestroyed = 0;


	void Start () {
		prefab = Resources.Load ("Platform") as GameObject;
		for (int i = 0; i < 20; i++) {
			spawnPlatforms ();

		}

		if (BounceBall.start) {
			time += Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () {
		if (BounceBall.start) {
			Time.timeScale = timeScale;
			time += Time.deltaTime;
			// Spawn every half second.
			if (time >= 0.5f) {
				time = 0;
				spawnPlatforms ();
			}


			if (currentPlatformClones > 30) {
				Destroy (GameObject.Find ("Platform " + (totalPlatformsDestroyed + 1).ToString ()));
				totalPlatformsDestroyed += 1;
				currentPlatformClones -= 1;
			}
		}

	}

	void spawnPlatforms() {
		platform = Instantiate (prefab) as GameObject;
		totalPlatformsInstantiated += 1;
		currentPlatformClones += 1;

		Vector3 position = new Vector3 (Random.Range(minRange, maxRange), 0.15f, (totalPlatformsInstantiated * distanceBetweenPlatforms )); // If there is bug look for y axis in Vector3 because if platform's height is changed the number is wrong.
		platform.transform.position = position;
	}

}
