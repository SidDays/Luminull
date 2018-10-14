using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject Target;
    public GameObject CameraForward;
    public GameObject Player;
    private Rigidbody CameraRB;
    public float distanceOffset = 4.75f;
    float XPosition = 0.0f;
    float YPosition = 0.0f;
    public float speed = 15.0f;
    public Vector3 CameraEulerAngles;
    public Vector3 PreviousDirection;
    public Vector3 ForwardDirection;

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
        /*XPosition = transform.position.x;
        YPosition = transform.position.y;
        CameraEulerAngles = transform.eulerAngles;
        PreviousDirection = Player.transform.forward;
        ForwardDirection = Target.transform.forward;*/
    }
	// Update is called once per frame
	void Update () {
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
        
        /*Vector3 CurrentEuler = transform.eulerAngles;
        CurrentEuler.x = CameraEulerAngles.x;
        CurrentEuler.z = CameraEulerAngles.z;
        transform.eulerAngles = CurrentEuler;*/
        //transform.position = Target.transform.forward
	}

    private void FixedUpdate()
    {
        /*Vector3 CurrentLocation = transform.position;
        Vector3 PlayerVelocity = Player.GetComponent<Rigidbody>().velocity * Time.deltaTime;
        PlayerVelocity.x = 0;
        CurrentLocation = CurrentLocation + PlayerVelocity;
        transform.position = CurrentLocation;
        transform.forward = Target.transform.forward;*/
    }
}
