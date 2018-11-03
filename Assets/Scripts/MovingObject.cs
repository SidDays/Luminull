using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

    public ObjectPath PathToFollow;
    public bool ResetOnLastWaypoint;
    public float MoveSpeed = 5f;
    public float DelayOnEnd = 0f;

    private Vector3 StartingPosition;
    private Transform CurrentWaypoint;
    private int CurrentWaypointIndex;
    private bool ShouldMove;
    private float DelayTimer = 0f;
    private bool DelayTimerSet = false;

	// Use this for initialization
	void Start () {
        if (PathToFollow.PathValid())
        {
            StartingPosition = transform.position;
            CurrentWaypointIndex = 0;
            CurrentWaypoint = PathToFollow.PathWaypoints[CurrentWaypointIndex];
            StartMotion();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(ShouldMove)
        {
            if (PathToFollow.PathValid())
            {
                transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, MoveSpeed*Time.deltaTime);
                if(Vector3.Distance(transform.position,CurrentWaypoint.position) < .1f)
                { 
                    if(CurrentWaypointIndex + 1 < PathToFollow.PathWaypoints.Count)
                    {
                        CurrentWaypoint = PathToFollow.PathWaypoints[++CurrentWaypointIndex];
                    }
                    else if(ResetOnLastWaypoint)
                    {
                        if((DelayOnEnd > 0 && DelayTimer < 0f) || DelayOnEnd <=0)
                        {
                            transform.position = StartingPosition;
                            CurrentWaypointIndex = 0;
                            CurrentWaypoint = PathToFollow.PathWaypoints[CurrentWaypointIndex];
                            DelayTimerSet = false;
                            DelayTimer = 0f;
                        }
                        else if(DelayOnEnd >0 && !DelayTimerSet)
                        {
                            DelayTimer = DelayOnEnd;
                            DelayTimerSet = true;
                            Debug.Log("here");
                        }
                    }
                }
            }

            if(DelayTimerSet)
            {
                DelayTimer -= Time.deltaTime;
            }
        }
	}

    public void StartMotion()
    {
        ShouldMove = true;
    }

    public void StopMotion()
    {
        ShouldMove = false;
    }

}
