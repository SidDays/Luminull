using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTemp : MonoBehaviour {

    public bool Colliding = false;
    Rigidbody PlayerRB;
    public float speed = 15.0f;

    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        
    }

    /*void Update()
    {
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = speed * Time.deltaTime;
        if (!Colliding)
        {

            //transform.Rotate(0, x, 0);
            //PlayerRB.velocity = transform.forward * speed * Time.fixedDeltaTime;
            //transform.Translate(0, 0, z);
            PlayerRB.AddForce(transform.forward * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

            /*if (Input.GetButtonDown("Fire1"))
            {
                transform.Rotate(0, 90, 0);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                transform.Rotate(0, -90, 0);
            }
        }
    }*/

    private void FixedUpdate()
    {
        PlayerRB.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Wall")
        {
            Colliding = true;
            PlayerRB.velocity = Vector3.zero;
            PlayerRB.freezeRotation = true;
            PlayerRB.angularVelocity = Vector3.zero;
        }*/
    }
}
