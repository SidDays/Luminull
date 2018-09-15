using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    private static readonly float SPEED = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * SPEED);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * SPEED);
        }
    }
}
