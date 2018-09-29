using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject Player;
    public Text playerScoreText;
    public Text playerSpeedText;
    public Text GameOverText;
    public Text WinText;
    public Button PlayAgainButton;
    public Slider MainSliderControl;
    public Button SpeedUpButton;
    public Button SpeedDownButton;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        SetPlayerScoreText(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPlayerScoreText(int val)
    {
        playerScoreText.text = "Score: " + val.ToString();
    }

    public void SetPlayerSpeedText(float val)
    {
        playerSpeedText.text = "Speed: " + val.ToString();
    }

    public void ToggleGameOverText()
    {
        GameOverText.gameObject.SetActive(true);
    }

    public void ToggleWinText()
    {
        WinText.gameObject.SetActive(true);
    }

    public void TogglePlayAgainButton()
    {
        PlayAgainButton.gameObject.SetActive(true);
    }

    public void SetPlayerSpeedWithDiff(float diff)
    {
        PlayerControllerTemp playerController = Player.GetComponent<PlayerControllerTemp>();
        if(playerController)
        {
            playerController.SetSpeedWithDiff(diff);
        }
    }
}
