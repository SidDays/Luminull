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
        if (other.gameObject.CompareTag("RefractionObject"))
        {
            float IndexOfIncidence = 1;
            float IndexOfRefraction = 4;
            if (!other.gameObject.GetComponent<RefractObject>().MirrorHit)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                float AngleBetweenReflectedPoints = Vector3.Angle(transform.forward, ReflectionAngle);
                float AngleOfIncidence = (180 - AngleBetweenReflectedPoints) / 2;
                Debug.Log(AngleOfIncidence);
                float AngleOfRefraction = Mathf.Asin(IndexOfIncidence * Mathf.Sin((AngleOfIncidence * Mathf.PI) / 180) / IndexOfRefraction);
                float AngleOfRefractionInDegrees = (Mathf.Asin(AngleOfRefraction) * 180) / Mathf.PI;
                Vector3 N = other.transform.forward;
                Vector3 s1 = transform.forward;
                Vector3 RefractionDir = (IndexOfIncidence / IndexOfRefraction) * (Vector3.Cross(N, Vector3.Cross(-N, s1))) - N * Mathf.Sqrt(1 - Mathf.Pow(IndexOfIncidence / IndexOfRefraction, 2) * Vector3.Dot(Vector3.Cross(N, s1), Vector3.Cross(N, s1)));
                transform.forward = RefractionDir;
                Debug.Log(AngleOfRefractionInDegrees);
                //Vector3 RefractionAngle = ;
                //transform.forward = ReflectionAngle;
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
