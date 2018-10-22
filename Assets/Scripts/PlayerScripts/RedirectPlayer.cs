using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectPlayer : MonoBehaviour {

    public Transform RedirectPointTransform;

    private Transform PlayerTransform;

    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
    }
    public void WarpPlayerToRedirectPoint()
    {
        PlayerTransform.position = RedirectPointTransform.position;

        //RedirectDirection object must be first child!
        Vector3 RedirectDirection = RedirectPointTransform.GetChild(0).forward;

        PlayerTransform.forward = RedirectDirection;
    }

}
