using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public List<AudioSource> SFXObjects;
    public List<AudioSource> MusicObjects;
    public Slider SFXSlider;
    public Slider MusicSlider;

    private void Start()
    {
        ChangeSFXVolume();
        ChangeMusicVolume();
    }

    public void ChangeSFXVolume()
    {
        if (SFXSlider != null)
        {
            for (int i = 0; i < SFXObjects.Count; i++)
            {
                SFXObjects[i].volume = SFXSlider.value;
            }
        }
    }

    public void ChangeMusicVolume()
    {
        if (MusicSlider != null)
        {
            for (int i = 0; i < MusicObjects.Count; i++)
            {
                MusicObjects[i].volume = MusicSlider.value;
            }
        }
    }

}
