using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {

    public float speed = 10.0f;
    public float TranslateOffset = 1.0f;

    //public bool XDirection = false;
    //public bool YDirection = true;
    //public bool ZDirection = false;

    private float CurrentXLocation;
    private float CurrentYLocation;
    private float CurrentZLocation;

    private bool FloatingUp = true;

	// Use this for initialization
	void Start () {
        CurrentXLocation = transform.position.x;
        CurrentYLocation = transform.position.y;
        CurrentZLocation = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(FloatingUp && Vector3.Distance(transform.position,transform.position + transform.forward*TranslateOffset) > 0.1f)
        {
            transform.position += transform.up * 0.1f;
            if(Vector3.Distance(transform.position, transform.position + transform.forward * TranslateOffset) < 0.1f)
            {
                FloatingUp = false;
            }
        }
        else if(Vector3.Distance(transform.position, transform.position - transform.forward * TranslateOffset) > 0.1f)
        {
            transform.position -= transform.up * 0.1f;
            if (Vector3.Distance(transform.position, transform.position + transform.forward * TranslateOffset) < 0.1f)
            {
                FloatingUp = true;
            }
        }
    }
}
