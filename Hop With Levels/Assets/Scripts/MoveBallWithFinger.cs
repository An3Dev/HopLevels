using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallWithFinger : MonoBehaviour {


//	float deviceWidth;
//	float left;
//	float right;

	//Vector3 movement;

	public float sensitivity;

	private Vector2 leftFingerPos = Vector2.zero;
	private Vector2 leftFingerLastPos = Vector2.zero;
	private Vector2 leftFingerMovedBy = Vector2.zero;

	float slideMagnitudeX = 0.0f;
//	public float slideMagnitudeY = 0.0f;



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

				Touch touch = Input.GetTouch (0);

				if (touch.phase == TouchPhase.Began) {
					leftFingerPos = Vector2.zero;
					leftFingerLastPos = Vector2.zero;
					leftFingerMovedBy = Vector2.zero;

					slideMagnitudeX = 0;
//					slideMagnitudeY = 0;

					// Record start position
					leftFingerPos = touch.position;
				}

				else if (touch.phase == TouchPhase.Moved)
				{
					leftFingerMovedBy = touch.position - leftFingerPos; // or Touch.deltaPosition : Vector2
					// The position delta since last change.
					leftFingerLastPos = leftFingerPos;
					leftFingerPos = touch.position;

					// slide horz
					slideMagnitudeX = leftFingerMovedBy.x / Screen.width;

//					// slide vert
//					slideMagnitudeY = (leftFingerMovedBy.y / Screen.height);

				}

				else if (touch.phase == TouchPhase.Stationary)
				{
					leftFingerLastPos = leftFingerPos;
					leftFingerPos = touch.position;

					slideMagnitudeX = 0.0f;
//					slideMagnitudeY = 0.0f;
				}

				else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
				{
					slideMagnitudeX = 0.0f;
//					slideMagnitudeY = 0.0f;
				}

//				if (Input.GetTouch (0).position.x < Screen.width / 2) {
//				
//					movement = new Vector3 (force * -1, 0.0f, 0.0f);
//				}
//				if (Input.GetTouch (0).position.x > Screen.width / 2) {
//					movement = new Vector3 (force, 0.0f, 0.0f);
//				}
//				transform.position += movement;

				transform.position += new Vector3 (slideMagnitudeX * sensitivity, 0, 0);
			}
		}
	}
}


