using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour
{

    public Transform RedirectPointTransform;

    private Transform PlayerTransform;
    //private GameStateController GameStateController;


    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
    
        //GameObject game = GameObject.Find("Game State Controller");
        //if (game == null)
        //    Debug.LogError("PlayerControllerTemp: Can not find Game State Controller.");
        //GameStateController = game.GetComponent<GameStateController>();
    }
    public void WarpPlayerToRedirectPoint1()
    {
        Debug.Log("Inside WarpPlayer method");
        //if (deathCount > 0)
        //{
            //deathCount--;
            PlayerTransform.position = RedirectPointTransform.position;

            //RedirectDirection object must be first child!
            Vector3 RedirectDirection = RedirectPointTransform.GetChild(0).forward;

            PlayerTransform.forward = RedirectDirection;
        //}
        //else
        //{
        //    GameStateController.OnPlayerLose();
        //}


    }
}






