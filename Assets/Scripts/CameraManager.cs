using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public GameObject Target;
    float distanceOffset = 4.75f;
    float YPosition = 0.0f;

    void Start()
    {
        YPosition = transform.position.y;
    }
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Target.transform.position.x, YPosition, Target.transform.position.z - distanceOffset);
	}
}
