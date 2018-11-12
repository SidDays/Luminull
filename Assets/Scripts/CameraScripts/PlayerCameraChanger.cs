using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraChanger : MonoBehaviour {
    public GameObject MainCamera;
    public GameObject Player;
    public float CameraTurnSpeed = 100.0f;
	void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("CameraChanger"))
        {
            CameraChangeWallProperties CameraWallProperties = other.gameObject.GetComponent<CameraChangeWallProperties>();
            if (CameraWallProperties.DirectionToTurn == CameraChangeWallProperties.CameraChangeDirection.LEFT)
            {
                MainCamera.transform.RotateAround(Player.transform.position, Vector3.up, 90 * Time.deltaTime);
            }
            else if(CameraWallProperties.DirectionToTurn == CameraChangeWallProperties.CameraChangeDirection.RIGHT)
            {
                MainCamera.transform.RotateAround(Player.transform.position, Vector3.up, -90 * Time.deltaTime);
            }

            /*float step = CameraTurnSpeed * Time.deltaTime;
            float OriginalXRot = MainCamera.transform.eulerAngles.x;
            Vector3 TargetDir = other.transform.forward;
            Vector3 NewDir = Vector3.RotateTowards(transform.forward, TargetDir,step,0.0f);
            MainCamera.transform.rotation = Quaternion.LookRotation(NewDir);
            Vector3 CameraEulerAngles = MainCamera.transform.eulerAngles;
            CameraEulerAngles.x = OriginalXRot;
            MainCamera.transform.eulerAngles = CameraEulerAngles;

            /*Vector3 CameraPosition = MainCamera.transform.position;
            float OriginalYPosition = CameraPosition.y;
            CameraPosition = Player.transform.position + MainCamera.transform.forward*MainCamera.GetComponent<CameraManager>().distanceOffset;
            CameraPosition.y = OriginalYPosition;
            MainCamera.transform.position = CameraPosition;
        }*/
    }
}
