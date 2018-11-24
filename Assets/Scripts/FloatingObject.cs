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
    private Vector3 TargetPosition;

	// Use this for initialization
	void Start () {
        CurrentXLocation = transform.position.x;
        CurrentYLocation = transform.position.y;
        CurrentZLocation = transform.position.z;
        TargetPosition = transform.position + transform.forward * TranslateOffset;

    }
	
	// Update is called once per frame
	void Update () {
		if(FloatingUp && Vector3.Distance(transform.position, TargetPosition) > 0.1f)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
            if(Vector3.Distance(transform.position, TargetPosition) < 0.1f)
            {
                FloatingUp = false;
                TargetPosition = transform.position + 2 *transform.forward * -TranslateOffset;
            }
        }
        else if(Vector3.Distance(transform.position, TargetPosition) > 0.1f)
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
            if (Vector3.Distance(transform.position, TargetPosition) < 0.1f)
            {
                FloatingUp = true;
                TargetPosition = transform.position + 2 *transform.forward * TranslateOffset;
            }
        }
    }
}
