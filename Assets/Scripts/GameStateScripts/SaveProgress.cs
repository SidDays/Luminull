using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour {

    public int LevelNumber = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveLevelProgress()
    {
        int CurrentLevelsCompleted = PlayerPrefs.GetInt("NumLevelsCompleted");
        PlayerPrefs.SetInt("NumLevelsCompleted", LevelNumber);
    }

    public void ResetLevelProgress()
    {
        PlayerPrefs.SetInt("NumLevelsCompleted", 0);
    }
}
