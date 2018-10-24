using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProgress : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveLevelProgress()
    {
        int CurrentLevelsCompleted = PlayerPrefs.GetInt("NumLevelsCompleted");
        PlayerPrefs.SetInt("NumLevelsCompleted", CurrentLevelsCompleted+1);
    }

    public void ResetLevelProgress()
    {
        PlayerPrefs.SetInt("NumLevelsCompleted", 0);
    }
}
