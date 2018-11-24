using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManger : MonoBehaviour {

    public GameObject MainCamera;
    public GameObject ResultsCamera;

    private GameStateController GameStateController;

    void Awake()
    {
        GameObject game = GameObject.Find("Game State Controller");
        if (game == null)
            Debug.LogError("PauseMenuManager: Can not find Game State Controller in the scene.\n");
        GameStateController = game.GetComponent<GameStateController>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnResumeButtonClick()
    {
        GameStateController.OnGameResume();

        ResultsCamera.SetActive(false);
        MainCamera.SetActive(true);
    }
}
