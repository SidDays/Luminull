using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    private Light FlickeringLight;
    private float FlickerTimer;
    private float LightRange;
	// Use this for initialization
	void Start () {
        FlickeringLight = GetComponent<Light>();
        FlickerTimer = .1f;//Random.Range(0f, 1f);
        LightRange = Random.Range(95f, 100f);
	}
	
	// Update is called once per frame
	void Update () {
        FlickeringLight.range = LightRange;
        FlickerTimer -= Time.deltaTime;
        if (FlickerTimer < 0)
        {
            FlickerTimer = 0.05f;
            LightRange = Random.Range(95f, 100f);
        }
	}
}
