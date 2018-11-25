using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardObject : MonoBehaviour {

    public float RotateSpeed = 1.0f;
    public List<GameObject> TargetLookPoints;

    private GameObject CurrentTargetLookPoint;

	// Use this for initialization
	void Start () {
        SetNextLookPoint();
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentTargetLookPoint != null)
        {
            Vector3 LookDirection = (CurrentTargetLookPoint.transform.position - transform.position).normalized;
            Quaternion LookRotation = Quaternion.LookRotation(LookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, RotateSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, LookRotation) < 0.5)
            {
                SetNextLookPoint();
            }
        }
	}

    private void SetNextLookPoint()
    {
        int RandInt = Random.Range(0, TargetLookPoints.Count);

        if (TargetLookPoints.Count > 1)
        {
            CurrentTargetLookPoint = TargetLookPoints[RandInt];
        }
    }
}
