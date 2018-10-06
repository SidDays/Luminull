using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeWallProperties : MonoBehaviour {

	public enum CameraChangeDirection
    {
        LEFT,
        RIGHT,
        FORWARD,
        BACKWARD
    }
    public CameraChangeDirection DirectionToTurn;
}
