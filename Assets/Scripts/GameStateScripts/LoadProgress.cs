using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadProgress : MonoBehaviour {

    public GameObject LevelPanel;
    public Sprite LevelIncompleteIcon;
    public Sprite LevelCompletedIcon;
    public Sprite LevelLockedIcon;

	// Use this for initialization
	void Start () {
		
	}
	
    void Awake()
    {
        LoadLevelProgress();
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void LoadLevelProgress()
    {
        int CurrentLevelsCompleted = PlayerPrefs.GetInt("NumLevelsCompleted");
        for (int i = 0; i < LevelPanel.transform.childCount; i++)
        {
            GameObject ProgressIcon = LevelPanel.transform.GetChild(i).Find("ProgressIcon").gameObject;
            if (ProgressIcon != null)
            {
                if (CurrentLevelsCompleted == 0 && i != 0)
                {
                    ProgressIcon.GetComponent<Image>().sprite = LevelLockedIcon;
                    ProgressIcon.GetComponent<Image>().enabled = true;
                    LevelPanel.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                else if (CurrentLevelsCompleted > i)
                {
                    ProgressIcon.GetComponent<Image>().sprite = LevelCompletedIcon;
                    LevelPanel.transform.GetChild(i).GetComponent<Image>().sprite = LevelCompletedIcon;
                    ProgressIcon.GetComponent<Image>().enabled = false;
                    LevelPanel.transform.GetChild(i).GetComponent<Button>().interactable = true;
                }
                else if (CurrentLevelsCompleted < i)
                {
                    ProgressIcon.GetComponent<Image>().sprite = LevelLockedIcon;
                    ProgressIcon.GetComponent<Image>().enabled = true;
                    LevelPanel.transform.GetChild(i).GetComponent<Button>().interactable = false;
                }
                else
                {
                    ProgressIcon.GetComponent<Image>().enabled = false;
                }
            }
        }
    }

    public void ResetLevelProgressIcons()
    {
        for (int i = 0; i < LevelPanel.transform.childCount; i++)
        {
            GameObject ProgressIcon = LevelPanel.transform.GetChild(i).Find("ProgressIcon").gameObject;
            if (ProgressIcon != null)
            {
                ProgressIcon.GetComponent<Image>().sprite = LevelIncompleteIcon;
                LevelPanel.transform.GetChild(i).GetComponent<Image>().sprite = LevelIncompleteIcon;
            }
        }
    }
}
