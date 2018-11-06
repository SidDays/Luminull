using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChangeIndicator : MonoBehaviour {

    public Sprite SpeedUpSprite;
    public Sprite SlowDownSprite;

    private Image changeImage;
    private Text speedText;

    private float lastingTime = 0.7f;
    private float timeCounter;
    private bool isSpeedUp;

    // Use this for initialization
    void Start () {
        changeImage = GetComponentInChildren<Image>();
        speedText = GetComponentInChildren<Text>();
        changeImage.enabled = false;
        speedText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            transform.position += (isSpeedUp) ? Vector3.up*0.5f : Vector3.down*0.5f;
        }
        else
        {
            changeImage.enabled = false;
            speedText.enabled = false;
            this.enabled = false;
        }
	}

    public void show(Vector2 location, float speed, bool _isSpeedUp)
    {
        isSpeedUp = _isSpeedUp;
        this.transform.position = location;
        changeImage.enabled = true;
        speedText.enabled = true;
        changeImage.sprite = isSpeedUp ? SpeedUpSprite : SlowDownSprite;
        speedText.text = ((int)speed).ToString();
        timeCounter = lastingTime;
    }
}
