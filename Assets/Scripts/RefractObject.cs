using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefractObject : MonoBehaviour {

    public bool MirrorHit = false;
    public bool AngleOfIncidenceSet = false;
    public float AngleOfIncidence;

    void Start()
    {
        AngleOfIncidence = 0.0f;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AngleOfIncidence = Vector3.Angle(collision.transform.forward, collision.contacts[0].normal);
            AngleOfIncidenceSet = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AngleOfIncidenceSet = false;
        }
    }
}
