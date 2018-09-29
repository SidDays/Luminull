using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

    public Canvas UI;
    public Canvas PauseMenu;

    private int PlayerScore;
    private UIManager UIManager;
    private PlayerControllerTemp PlayerController;

    private bool isGamePaused;

    void Awake()
    {
        UIManager = UI.GetComponent<UIManager>();
        GameObject player = GameObject.Find("Player");
        if (player == null)
            Debug.Log("GameStateController: Can not find Player in scene.\n");
        PlayerController = player.GetComponent<PlayerControllerTemp>();
    }

    // Use this for initialization
    void Start () {
        isGamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayerLose()
    {
        UIManager.ToggleGameOverText();
        UIManager.TogglePlayAgainButton();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnPlayerWin()
    {
        UIManager.ToggleWinText();
        UIManager.TogglePlayAgainButton();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnApplicationPause(bool pause)
    {
        if (pause) OnGamePause();
    }

    public void OnGamePause()
    {
        UI.enabled = false;
        UIManager.GetComponent<Timer>().isPaused = true;
        PauseMenu.enabled = true;
        PlayerController.OnPause();
    }

    public void OnGameResume()
    {
        UI.enabled = true;
        UIManager.GetComponent<Timer>().isPaused = false;
        PauseMenu.enabled = false;
        PlayerController.OnResume();
    }
}
