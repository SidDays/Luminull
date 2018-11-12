using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeWallProperties : MonoBehaviour
{
    public GameObject CameraWaypointToLerpTo;

    private GameObject MainCamera;
    private bool LerpToCameraWaypoint = false;
    private float LerpSpeed = 2.0f;

    private void Start()
    {
        MainCamera = GameObject.Find("Main Camera");    
    }

    private void Update()
    {
        if(LerpToCameraWaypoint)
        {
            MainCamera.transform.position = Vector3.Slerp(MainCamera.transform.position, CameraWaypointToLerpTo.transform.position, LerpSpeed*Time.deltaTime);
            MainCamera.transform.rotation = Quaternion.Lerp(MainCamera.transform.rotation, CameraWaypointToLerpTo.transform.rotation, LerpSpeed*Time.deltaTime);
            if (Vector3.Distance(MainCamera.transform.position, CameraWaypointToLerpTo.transform.position) < 0.1f)
            {
                //MainCamera.transform.parent = CameraWaypointToLerpTo.transform;
                //MainCamera.transform.localPosition = new Vector3(0,0,0);
                //MainCamera.transform.localEulerAngles = new Vector3(0, 0, 0);
                LerpToCameraWaypoint = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(MainCamera!=null)
            {
                LerpToCameraWaypoint = true;
            }
        }
    }

}
