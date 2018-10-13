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
    public Text GameStateAnnounceText;
    public Image PlayerBrightnessFiller;
    public Button PlayAgainButton;
    public Slider MainSliderControl;
    public GameObject FinalScorePanel;
    public Text FinalCoinsCollectedText;
    public Text FinalTimeText;
    public Text TopSpeedText;
    public Text FinalScoreText;
    public float speedChangeInterval = 0.5f;

    static private float TimeMultiplier = 10.0f;
    static private float TopSpeedMultiplier = 5.0f;
    private float TopSpeed;
    private float FinalTime;
    private int CurrentScore;
    private GameStateController GameStateController;
    private float speedChangeCounter;
    private int speedStatus; // 0: nothing, 1: speedUp, -1: speedDown

    void Awake()
    {
        GameObject game = GameObject.Find("Game State Controller");
        if (game == null)
            Debug.LogError("UIManager: Can not find Game State Controller in the scene.\n");
        GameStateController = game.GetComponent<GameStateController>();
    }

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        TopSpeed = 0;
        CurrentScore = 0;
        FinalTime = 0;
        SetPlayerScoreText(0);
        speedStatus = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(speedStatus != 0)
        {
            speedChangeCounter += Time.deltaTime;
            if(speedChangeCounter > speedChangeInterval)
            {
                speedChangeCounter = 0;
                SetPlayerSpeedWithDiff(speedStatus);
            }
        }
	}

    public void SetPlayerScoreText(int val)
    {
        CurrentScore += 0;
        playerScoreText.text = "Score: " + val.ToString();
        FinalCoinsCollectedText.text = "Coins: " + val.ToString();
    }

    public void SetPlayerSpeedText(float val)
    {
        if(val>TopSpeed)
        {
            TopSpeed = val;
        }

        playerSpeedText.text = "Speed: " + val.ToString();
        TopSpeedText.text = "Top Speed: " + TopSpeed.ToString();
    }

    public void SetFinalTimeText()
    {
        FinalTime = GetComponent<Timer>().GetElapsedTime();

        string minutes = ((int)FinalTime / 60).ToString("f2");
        string seconds = (FinalTime % 60).ToString("f2");
        FinalTimeText.text = "Time: " + minutes + ":" + seconds;
    }

    public void SetFinalScoreText()
    {
        float TotalScore = CurrentScore + TopSpeedMultiplier * TopSpeed + TimeMultiplier*FinalTime;
        FinalScoreText.text = "Total: " + TotalScore.ToString();
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

    public void ToggleFinalScorePanel()
    {
        FinalScorePanel.SetActive(true);
    }

    public void SetPlayerSpeedWithDiff(float diff)
    {
        PlayerControllerTemp playerController = Player.GetComponent<PlayerControllerTemp>();
        if(playerController)
        {
            playerController.SetSpeedWithDiff(diff);
        }
    }

    public void OnPauseButtonClick()
    {
        GameStateController.OnGamePause(true);
    }

    public void OnSpeedChangeButtonDown(bool isSpeedUp)
    {
        speedChangeCounter = 0;
        speedStatus = (isSpeedUp) ? 1 : -1;
    }

    public void OnSpeedChangeButtonUp()
    {
        speedStatus = 0;
    }

    public void SetPlayerBrightnessFiller(float percentage)
    {
        PlayerBrightnessFiller.fillAmount = percentage;
    }
}
