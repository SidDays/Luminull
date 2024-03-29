﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject ResultsCamera;
    public GameObject ResultsLight;
    public Text GameStateAnnounceText;
    public Image PlayerBrightnessFiller;
    public Button NextLevelButton;
    public Slider MainSliderControl;
    public Canvas MainCanvas;
    public Canvas ResultsMenu;
    //public Text FinalCoinsCollectedText;
    //public Text FinalTimeText;
    //public Text TopSpeedText;
    public Text FinalScoreText;
    public TextMeshProUGUI ResultsTitleText;
    public TextMeshProUGUI ResultsSubtitleText;
    public Text PlayAgainButtonText;
    public Text MainMenuButtonText;
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
    private float speedChangeCounter; // Deprecated
    private int speedStatus; // 0: nothing, 1: speedUp, -1: speedDown - Deprecated
    private float speedChangeDelayCounter;
    private SpeedChangeIndicator speedChangeIndicator;

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
        speedChangeIndicator = GetComponentInChildren<SpeedChangeIndicator>();
    }
	
	// Update is called once per frame
	void Update () {
        // speed button event - Deprecated
        if (speedStatus != 0)
        {
            speedChangeCounter += Time.deltaTime;
            if(speedChangeCounter > speedChangeInterval)
            {
                speedChangeCounter = 0;
                SetPlayerSpeedWithDiff(speedStatus);
            }
        }

        if(speedChangeDelayCounter <= 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                // Get movement of the finger since last frame
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                if (touchDeltaPosition.sqrMagnitude > 1000.0f)
                {
                    PlayerController playerController = Player.GetComponent<PlayerController>();
                    if (touchDeltaPosition.y > 0)
                    {
                        SetPlayerSpeedWithDiff(1);
                        speedChangeIndicator.enabled = true;
                        speedChangeIndicator.show(Input.GetTouch(0).position, playerController.GetSpeed(), true);
                    }
                    else
                    {
                        SetPlayerSpeedWithDiff(-1);
                        speedChangeIndicator.enabled = true;
                        speedChangeIndicator.show(Input.GetTouch(0).position, playerController.GetSpeed(), false);
                    }
                    speedChangeDelayCounter = speedChangeInterval;
                }
            }
        }
        else
        {
            speedChangeDelayCounter -= Time.deltaTime;
        }
    }

    public void SetPlayerScoreText(int val)
    {
        CurrentScore += 0;
       // playerScoreText.text = "Score: " + val.ToString();
        //FinalCoinsCollectedText.text = "Coins: " + val.ToString();
    }

    public void SetPlayerSpeedText(float val)
    {
        if(val>TopSpeed)
        {
            TopSpeed = val;
        }

        //playerSpeedText.text = "Speed: " + val.ToString();
        //TopSpeedText.text = "Top Speed: " + TopSpeed.ToString();
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
        //FinalTimeText.text = "Time: " + minutes + ":" + secondsString;
    }

    public void SetFinalScoreText(bool Won)
    {
        float TotalScore = CurrentScore + TopSpeedMultiplier * TopSpeed + MaxTimeScore - FinalTime;
        if (Won)
        {
            TotalScore += WinningBonus;
        }

        int TotalScoreInt = (int)TotalScore;
        FinalScoreText.text = TotalScoreInt.ToString();
    }

    public void ToggleFinalScorePanel(bool Won)
    {
        if (Won)
        {
            NextLevelButton.gameObject.SetActive(true);
            PlayAgainButtonText.text = "Play Again";
            ResultsTitleText.text = "The Light Has";
            ResultsSubtitleText.text = "ENDURED";
            MainCamera.SetActive(false);
            ResultsCamera.SetActive(true);
            ResultsLight.SetActive(true);
        }
        else
        {
            NextLevelButton.gameObject.SetActive(false);
            PlayAgainButtonText.text = "Try Again";
            ResultsTitleText.text = "The Light Has Been";
            ResultsTitleText.color = new Color(255, 255, 255);
            ResultsSubtitleText.text = "CONSUMED";
            ResultsSubtitleText.color = new Color32(168, 0, 8,255);
            PlayAgainButtonText.color = new Color(255, 255, 255);
            MainMenuButtonText.color = new Color(255, 255, 255);
            MainCamera.SetActive(false);
            ResultsCamera.SetActive(true);
            ResultsLight.SetActive(false);
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

        MainCamera.SetActive(false);
        ResultsCamera.SetActive(true);
    }

    // speed button click event - Deprecated
    public void OnSpeedChangeButtonDown(bool isSpeedUp)
    {
        speedChangeCounter = 0;
        speedStatus = (isSpeedUp) ? 1 : -1;
    }
    // speed button click event - Deprecated
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
