using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{

    public TextMeshProUGUI instructText;
    public static int count;
    public Button OK_button;
    public GameObject InstructionsPanel;

    private bool RotateMirrorTutorialActivated = false;
    private bool RotateMirrorTutorialFinished = false;
    private bool SwitchMirrorsTutorialActivated = false;
    private GameStateController MainGameStateController;

    // Use this for initialization
    void Start () {

        Debug.Log("In start");
        GameObject StateController = GameObject.Find("Game State Controller");
        if (StateController != null)
        {
            MainGameStateController = StateController.GetComponent<GameStateController>();
        }
        //OK_button = GetComponent<Button>();
        OK_button.gameObject.SetActive(false);
        //instructText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider checkpoint)
    {
        if (checkpoint.gameObject.CompareTag("Player"))
        {
            OK_button.gameObject.SetActive(true);
            InstructionsPanel.SetActive(true);
            Debug.Log("Inside if");   
            Time.timeScale = 0;

            Debug.Log("After Pause");


            if (count == 0)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "Welcome to Light The Void. The goal of the game is to reach the end of the level and destroy the Void as fast as possible.";
                count++;
                Destroy(gameObject);
            }
            else if (count == 1)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Mirrors are the way you guide your light in this world. Click on the large glowing round button to rotate the currently selected mirror.";
                count++;
                RotateMirrorTutorialActivated = true;
                OK_button.gameObject.SetActive(false);
            }
            else if (count == 2)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "To select other mirrors, use the right and left arrow buttons or tap on a mirror to select it. Try tapping on the right arrow button now to select the next mirror.";
                count++;
                SwitchMirrorsTutorialActivated = true;
                OK_button.gameObject.SetActive(false);
            }
            else if (count == 3)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "The golden line ahead of you is your guiding light. Use it to determine the path you will travel.";
                count++;
                Destroy(gameObject);
            }
            else if(count == 4)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Not all mirrors will rotate horizontally, some will rotate vertically as well. Keep an eye on the path to determine which way a mirror might move.";
                count++;
                Destroy(gameObject);
            }
            else if (count == 5)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "Sometimes you may need a little more reaction time. Swipe down on the screen to slow your light down.";
                count++;
                Destroy(gameObject);
            }
            else if (count == 6)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "There may be dangerous obstacles along the way. If you're in danger, your light will turn red. Adjust your speed by swiping up to speed up or down to slow down.";
                count++;
                Destroy(gameObject);
            }
            else if (count == 7)
            {
                OK_button.gameObject.SetActive(true);
                instructText.text = "";
                instructText.text = "The meter on top of the screen is your brightness meter. If it runs out, your light is consumed. Collect light orbs to gain more brightness.";
                count++;
                Destroy(gameObject);
            }

        }


    }

        
    public void resumeGame(){

        instructText.text = "";

        Time.timeScale = 1;

        OK_button.gameObject.SetActive(false);
        InstructionsPanel.SetActive(false);


    }

    public void RotateMirrorButtonTutorial()
    {
        if(RotateMirrorTutorialActivated && !RotateMirrorTutorialFinished)
        {
            MainGameStateController.ResumeGameFromTutorial();
            Destroy(gameObject);
            RotateMirrorTutorialFinished = true;
        }
    }

    public void SwitchMirrorButtonTutorial()
    {
        if (SwitchMirrorsTutorialActivated)
        {
            MainGameStateController.ResumeGameFromTutorial();
            Destroy(gameObject);
        }
    }


}
