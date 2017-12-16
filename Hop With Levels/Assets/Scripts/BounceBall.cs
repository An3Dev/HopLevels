using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BounceBall : MonoBehaviour {

	float time;

	public static bool start = false;

	public Rigidbody rb;

	float storedVelocity;

	public float yVelocity;

	bool turnCamera = false;

	public Camera mainCamera;


	void Start() {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (0, yVelocity, 0);
		storedVelocity = rb.velocity.y;
	}

	void Update() {
		if (Input.GetMouseButton (0) || turnCamera) {
			turnCamera = true;
			if (mainCamera.transform.eulerAngles.x < 15) {
				mainCamera.transform.eulerAngles += new Vector3(0.5f, 0, 0);
			}
			if (mainCamera.transform.eulerAngles.x >= 15) {
				start = true;
			}
				


		}
	}

	

	void OnCollisionEnter(Collision collision) {
		//Debug.Log ("Time: " + Time.time);
		if (start) {
			rb.velocity = new Vector3 (0, storedVelocity, storedVelocity * 2);
		} else {
			rb.velocity = new Vector3 (0, storedVelocity, 0);

		}
	}

}