using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionController : MonoBehaviour
{
    public GameObject Player;
    private int deathCount = 1;
    private GameStateController GameStateController;

    private void Start()
    {

        GameObject game = GameObject.Find("Game State Controller");
        if (game == null)
            Debug.LogError("PlayerControllerTemp: Can not find Game State Controller.");
            GameStateController = game.GetComponent<GameStateController>();


    }
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

        if (other.gameObject.CompareTag("RedirectWall"))
        {
            other.gameObject.GetComponent<RedirectPlayer>().WarpPlayerToRedirectPoint();
        }

        if (other.gameObject.CompareTag("WallObstacle"))
        {
            Debug.Log("Inside PlayerDirectionController");
            if (deathCount > 0)
            {
                deathCount--;
                other.gameObject.GetComponent<WallObstacle>().WarpPlayerToRedirectPoint1();

            }
            else{
                GameStateController.OnPlayerLose();
            }
        }
    }
}