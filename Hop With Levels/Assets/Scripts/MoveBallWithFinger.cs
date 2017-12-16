using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallWithFinger : MonoBehaviour {


//	float deviceWidth;
//	float left;
//	float right;

	Vector3 movement;

	public float force;


	public float moveTime = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		deviceWidth = Screen.width;
//		left = (deviceWidth / 2) * -1;
//		right = deviceWidth / 2;

		if (BounceBall.start) {

			if (Input.touchCount >= 1) {

				if (Input.GetTouch (0).position.x < Screen.width / 2) {
				
					movement = new Vector3 (force * -1, 0.0f, 0.0f);
				}
				if (Input.GetTouch (0).position.x > Screen.width / 2) {
					movement = new Vector3 (force, 0.0f, 0.0f);
				}
				transform.position += movement;
			}
		}
	}
}


