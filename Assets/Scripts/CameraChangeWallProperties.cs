using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeWallProperties : MonoBehaviour {

	public enum CameraChangeDirection
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    public CameraChangeDirection DirectionToTurn;
}
