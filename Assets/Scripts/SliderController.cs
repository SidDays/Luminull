using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
    public Slider slider;
    public bool adjustingSlider = false;


    void OnEnable()
    {
        slider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(slider.value);
    }
    void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    void ChangeValue(float value)
    {
        if(value != slider.value)
        {
            adjustingSlider = true;
        }
        else
        {
            adjustingSlider = false;
        }
    }
}
