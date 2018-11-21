using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour {

    public List<AudioClip> RandomSoundEffects;
    public AudioSource SoundEffectSource;
    public bool OnLoop = true;

    private bool SoundEffectPlaying;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OnLoop)
        {
            int RandInt = Random.Range(0, RandomSoundEffects.Count);

            if(RandomSoundEffects.Count > 1 && !SoundEffectSource.isPlaying)
            {
                AudioClip NextClip = RandomSoundEffects[RandInt];
                SoundEffectSource.clip = NextClip;
                SoundEffectSource.Play();
            }
        }
	}
}
