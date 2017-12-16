using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorChange : MonoBehaviour {


	public float switchTime;

	public float transitionTime;

	float time;

	float timeLeft;
	Color targetColor;


	void Start () 
	{

	}

	void Update()
	{

		time += Time.deltaTime;
		//Debug.Log (time + "");
		if (switchTime >= time)
		{
			time = 0;
			if (timeLeft <= Time.deltaTime)
			{
				// transition complete
				// assign the target color
				gameObject.GetComponent<Renderer>().material.color = targetColor;

				// start a new transition
				targetColor = new Color(Random.value, Random.value, Random.value);
				timeLeft = transitionTime;
			}
			else
			{
				// transition in progress
				// calculate interpolated color
				gameObject.GetComponent<Renderer>().material.color = Color.Lerp(gameObject.GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);

				// update the timer
				timeLeft -= Time.deltaTime;
			}
		



		}

	}




}
