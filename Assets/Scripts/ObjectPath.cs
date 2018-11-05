using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPath : MonoBehaviour {

    public List<Transform> PathWaypoints;

    public bool PathValid()
    {
        return PathWaypoints.Count > 0;
    }

    private void OnDrawGizmos()
    {
        if (PathWaypoints.Count > 0)
        {
            for (int i = 0; i < PathWaypoints.Count; i++)
            {
                if (PathWaypoints[i] != null)
                {
                    Gizmos.DrawSphere(PathWaypoints[i].position, .5f);
                }
            }

            for(int i=0; i<PathWaypoints.Count;i++)
            {
                if(i<=PathWaypoints.Count-2)
                {
                    if (PathWaypoints[i] != null)
                    {
                        Gizmos.DrawLine(PathWaypoints[i].position, PathWaypoints[i + 1].position);
                    }
                }
            }
        }
    }
}
