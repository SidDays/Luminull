using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public GameObject Player;
    public GameObject MainCamera;
    public Text GameStateAnnounceText;
    public Image PlayerBrightnessFiller;
    public Button NextLevelButton;
    public Slider MainSliderControl;
    public Canvas MainCanvas;
    public Canvas ResultsMenu;
    public Text FinalCoinsCollectedText;
    public Text FinalTimeText;
    public Text TopSpeedText;
    public Text FinalScoreText;
    public Text PlayAgainButtonText;
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
        MainCanvas = GetComponent<Canvas>();
    }

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        MainCamera = GameObject.Find("Main Camera");
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
       // playerScoreText.text = "Score: " + val.ToString();
        FinalCoinsCollectedText.text = "Coins: " + val.ToString();
    }

    public void SetPlayerSpeedText(float val)
    {
        if(val>TopSpeed)
        {
            TopSpeed = val;
        }

        //playerSpeedText.text = "Speed: " + val.ToString();
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

    public void ToggleFinalScorePanel(bool Won)
    {
        if (Won)
        {
            NextLevelButton.gameObject.SetActive(true);
            PlayAgainButtonText.text = "Play Again";
        }
        else
        {
            NextLevelButton.gameObject.SetActive(false);
            PlayAgainButtonText.text = "Try Again";
        }

        if (MainCanvas)
        {
            MainCanvas.enabled = false;
        }

        if (MainCamera != null)
        {
            if (MainCamera.GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>() != null)
            {
                MainCamera.GetComponent<UnityEngine.PostProcessing.PostProcessingBehaviour>().enabled = true;
            }
        }

        ResultsMenu.enabled = true;
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
