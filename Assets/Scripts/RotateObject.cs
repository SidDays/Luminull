using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    private static readonly float MirrorRotateSpeed = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
    }

    private void OnMouseOver()
    {
        //if (Input.GetKey(KeyCode.LeftArrow))
        // {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * MirrorRotateSpeed);
        }
       // }
       // else if (Input.GetKey(KeyCode.RightArrow))
       // {
       //     transform.Rotate(Vector3.down * Time.deltaTime * MirrorRotateSpeed);
       // }
    }
}
