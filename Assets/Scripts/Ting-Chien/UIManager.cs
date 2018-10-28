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
    static private float MaxTimeScore = 3000;
    static private float WinningBonus = 2000;
    static private float TopSpeedMultiplier = 5.0f;
    private float TopSpeed;
    private float FinalTime;
    private int CurrentScore;
    private GameStateController GameStateController;
    private MirrorManager MirrorManager;
    private float speedChangeCounter;
    private int speedStatus; // 0: nothing, 1: speedUp, -1: speedDown

    void Awake()
    {
        GameObject game = GameObject.Find("Game State Controller");
        if (game == null)
            Debug.LogError("UIManager: Can not find Game State Controller in the scene.\n");
        GameStateController = game.GetComponent<GameStateController>();
        MirrorManager = game.GetComponent<MirrorManager>();

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

        string minutes = ((int)FinalTime / 60).ToString();
        int seconds = (int)FinalTime % 60;
        string secondsString = "";
        if(seconds < 10)
        {
            secondsString = "0" + ((int)FinalTime % 60).ToString();
        }
        else
        {
            secondsString = ((int)FinalTime % 60).ToString();
        }
        FinalTimeText.text = "Time: " + minutes + ":" + secondsString;
    }

    public void SetFinalScoreText(bool Won)
    {
        float TotalScore = CurrentScore + TopSpeedMultiplier * TopSpeed + MaxTimeScore - FinalTime;
        if (Won)
        {
            TotalScore += WinningBonus;
        }

        int TotalScoreInt = (int)TotalScore;
        FinalScoreText.text = "Total: " + TotalScoreInt.ToString();
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

        ResultsMenu.enabled = true;
    }

    public void SetPlayerSpeedWithDiff(float diff)
    {
        PlayerController playerController = Player.GetComponent<PlayerController>();
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

    public void OnRotateMirrorButtonClick()
    {
        MirrorManager.RotateCurrentSelectedMirror();
    }

    public void OnPreviousMirrorButtonClick()
    {
        MirrorManager.SelectPreviousMirror();
    }

    public void OnNextMirrorButtonClick()
    {
        MirrorManager.SelectNextMirror();
    }
}
