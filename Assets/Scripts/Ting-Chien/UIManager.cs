using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text playerScoreText;
    public Text playerSpeedText;

	// Use this for initialization
	void Start () {
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
}
