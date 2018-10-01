using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour {

    public Text timerText;
    public bool isPaused;
    //private float startTime;
    private float PlayedTime;
    private bool finnished = false;

	// Use this for initialization
	void Start () {
        //startTime = Time.time;
        PlayedTime = 0.0f;
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (finnished || isPaused)
            return;

        PlayedTime += Time.deltaTime;
        //float t = Time.time - startTime;
        float t = PlayedTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = "Time: " + minutes + ":" + seconds;

	}

    public float GetElapsedTime()
    {
        return PlayedTime;
    }
}
