using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDefault : MonoBehaviour {
	private static readonly float PlayerSpeed = 1.125f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.forward * Time.deltaTime * PlayerSpeed;

		// for debugging purposes, reset the position of the cube if the spacebar is pressed
		if (Input.GetKey(KeyCode.Space)) {
			transform.position = new Vector3(0, 0.125f, -3.261f);
		}
	}
}
