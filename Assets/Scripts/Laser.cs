using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float speed = 15.0f;
    public float lifetime = 120.0f;
    private bool HitMirror = false;
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime<0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Rigidbody LaserRB = GetComponent<Rigidbody>();
        LaserRB.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mirror"))
        {
            if (!HitMirror)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                transform.forward = ReflectionAngle;
                HitMirror = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Mirror"))
        {
            HitMirror = false;
        }
    }
}
