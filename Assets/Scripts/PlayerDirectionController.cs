using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        transform.position = Player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CameraChanger"))
        {
            transform.forward = other.transform.forward;
        }
    }
}