using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject Target;
    public GameObject CameraForward;
    private Rigidbody CameraRB;
    public float distanceOffset = 4.75f;
    float YPosition = 0.0f;
    public float speed = 15.0f;
    public Vector3 CameraEulerAngles;

    public enum CameraDirection
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }

    public CameraDirection CurrentCameraDirection = CameraDirection.UP;

    void Start()
    {
        YPosition = transform.position.y;
        CameraEulerAngles = transform.eulerAngles;
    }
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position);
        /*switch(CurrentCameraDirection)
        {
            case CameraDirection.LEFT:
                {
                    break;
                }
            case CameraDirection.RIGHT:
                {
                    break;
                }
            case CameraDirection.UP:
                {
                    break;
                }
            case CameraDirection.DOWN:
                {
                    break;
                }
        }*/
        transform.forward = Target.transform.forward;
        Vector3 CurrentEuler = transform.eulerAngles;
        CurrentEuler.x = CameraEulerAngles.x;
        CurrentEuler.z = CameraEulerAngles.z;
        transform.eulerAngles = CurrentEuler;
        //transform.position = Target.transform.forward
	}

    private void FixedUpdate()
    {
    }
}
