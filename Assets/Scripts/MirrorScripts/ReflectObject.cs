using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectObject : MonoBehaviour {

    public bool MirrorHit = false;

	private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(transform.forward);
        if(collision.gameObject.tag == "Player")
        {
            //Vector3 ReflectionVector = Vector3.Reflect(collision.transform.forward, collision.contacts[0].normal);
            collision.transform.forward = transform.forward;//collision.contacts[0].normal;//ReflectionVector;
           // collision.gameObject.GetComponent<Rigidbody>().velocity = transform.forward *15.0f;
            //collision.transform.forward = transform.forward;
        }
    }
}
