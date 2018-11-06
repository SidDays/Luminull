using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectOverTime : MonoBehaviour {

    public float RotateXSpeed = 0;
    public float RotateYSpeed = 1;
    public float RotateZSpeed = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(RotateXSpeed, RotateYSpeed, RotateZSpeed));
	}
}
