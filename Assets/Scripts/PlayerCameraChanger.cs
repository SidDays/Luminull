using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraChanger : MonoBehaviour {
    public GameObject MainCamera;
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraChanger"))
        {
            
           // MainCamera.transform.RotateTowards(other.transform.forward);
        }
    }
}
