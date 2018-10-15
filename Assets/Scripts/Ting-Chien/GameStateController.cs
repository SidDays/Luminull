using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour {

    public Canvas UI;
    public Canvas PauseMenu;
    public float PlayerBrightnessBeginValue;
    public float PlayerBrightnessDecreaseRatePerSec;

    private float PlayerBrightness;
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
        isGamePaused = false;
    }

    // Use this for initialization
    void Start () {
        PlayerBrightness = PlayerBrightnessBeginValue;
        StartCoroutine(BeginCountDownThenStart());
    }
	
	// Update is called once per frame
	void Update () {
        if(!isGamePaused)
        {
            PlayerBrightness -= PlayerBrightnessDecreaseRatePerSec * Time.deltaTime;
            PlayerBrightness = Mathf.Clamp(PlayerBrightness, 0.0f, 100.0f);
            if(PlayerBrightness <= 0.0f)
            {
                OnPlayerLose();
            }
        }
        UIManager.SetPlayerBrightnessFiller(PlayerBrightness / 100.0f);
    }

    public void OnPlayerLose()
    {
        UIManager.SetFinalTimeText();
        UIManager.SetFinalScoreText();
        UIManager.ToggleFinalScorePanel(false);
        OnGamePause(false);
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void OnPlayerWin()
    {
        UIManager.SetFinalTimeText();
        UIManager.SetFinalScoreText();
        UIManager.ToggleFinalScorePanel(true);
        OnGamePause(false);
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            isGamePaused = true;
            OnGamePause(true);
        }
        else
        {
            isGamePaused = false;
            OnGameResume();
        }
    }

    public void OnGamePause(bool showPauseMenu)
    {
        isGamePaused = true;
        UIManager.GetComponent<Timer>().isPaused = true;
        if(showPauseMenu)
        {
            UI.enabled = false;
            PauseMenu.enabled = true;
        }
        PlayerController.OnPause();
    }

    public void OnGameResume()
    {
        isGamePaused = false;
        UIManager.GetComponent<Timer>().isPaused = false;
        if(UI.enabled == false)
        {
            UI.enabled = true;
            PauseMenu.enabled = false;
        }
        PlayerController.OnResume();
    }

    public void SetPlayerBrightnessDiff(float val)
    {
        PlayerBrightness += val;
        PlayerBrightness = Mathf.Clamp(PlayerBrightness, 0.0f, 100.0f);
    }

    private IEnumerator BeginCountDownThenStart()
    {
        PlayerController.SetSpeed(2.0f);
        OnGamePause(false);
        for (int sec = 3; sec > 0; sec--)
        {
            UIManager.GameStateAnnounceText.text = sec.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        UIManager.GameStateAnnounceText.text = "";
        UIManager.GameStateAnnounceText.enabled = false;
        OnGameResume();
    }
}
