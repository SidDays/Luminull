using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTemp : MonoBehaviour {

    public bool Colliding = false;
    Rigidbody PlayerRB;
    public GameObject LaserObject;
    public float speed = 15.0f;
    public static float LaserNormalSpeed = 0.5f;
    public float LaserSpawnSpeed = LaserNormalSpeed;
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody>();
        /*GameObject NewLaser = Instantiate(LaserObject);
        //NewLaser.transform.parent = transform;
        NewLaser.transform.position = transform.position;
        NewLaser.transform.forward = transform.forward;
        Physics.IgnoreCollision(NewLaser.GetComponent<Collider>(), GetComponent<Collider>());
        */
     }

    void Update()
    {
        LaserSpawnSpeed -= Time.deltaTime;
        if(LaserSpawnSpeed<0.0f)
        {
            GameObject NewLaser = Instantiate(LaserObject);
            //NewLaser.transform.parent = transform;
            NewLaser.transform.position = transform.position;
            NewLaser.transform.forward = transform.forward;
            Physics.IgnoreCollision(NewLaser.GetComponent<Collider>(), GetComponent<Collider>());
            LaserSpawnSpeed = LaserNormalSpeed;
        }
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        /*var z = speed * Time.deltaTime;
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
        }*/
    }

    private void FixedUpdate()
    {
        PlayerRB.velocity = transform.forward * speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin Pick Up"))
        {
            CoinPickUp script = other.GetComponent<CoinPickUp>();
            script.OnPickUp();
        }

        if (other.gameObject.CompareTag("Mirror"))
        {
            if (!other.gameObject.GetComponent<ReflectObject>().MirrorHit)
            {
                Vector3 ReflectionAngle = Vector3.Reflect(transform.forward, other.transform.forward);
                transform.forward = ReflectionAngle;
                other.gameObject.GetComponent<ReflectObject>().MirrorHit = true;
            }
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

}
