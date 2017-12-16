using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	private Vector3 follow;

	public float playerZ;

	public float playerX;

	public GameObject player;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		playerZ = player.transform.position.z - 10;

		playerX = player.transform.position.x;
		follow = new Vector3(playerX / 10, 4f,playerZ);

		transform.position = follow;
	}
}
