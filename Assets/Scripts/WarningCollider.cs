using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCollider : MonoBehaviour
{
    private GameObject Player;
    private AudioSource WarningSound;
    private ParticleSystem PlayerParticleSystemInner;
    private ParticleSystem.MinMaxGradient PlayerParticleSystemInnerColor;
    private ParticleSystem.MainModule PlayerParticleSystemInnerMain;
    private ParticleSystem PlayerParticleSystemOuter;
    private ParticleSystem.MinMaxGradient PlayerParticleSystemOuterColor;
    private ParticleSystem.MainModule PlayerParticleSystemOuterMain;
    private float WarningFlashInterval = 0.0f;
    private float WarningFlashSpeed = .1f;
    private bool WarningFlashActivated = false;
    private bool WarningColorActive = false;
    private bool FadeWarningSound = false;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");

        if (GameObject.Find("WarningSound") != null)
        {
            WarningSound = GameObject.Find("WarningSound").GetComponent<AudioSource>();
        }

        if (Player != null)
        {
            Transform PlayerParticleSystemInnerTransform = Player.transform.Find("PlayerParticleSystemInner");
            if (PlayerParticleSystemInnerTransform != null)
            {
                PlayerParticleSystemInner = PlayerParticleSystemInnerTransform.GetComponent<ParticleSystem>();
                PlayerParticleSystemInnerColor = PlayerParticleSystemInner.main.startColor;
                PlayerParticleSystemInnerMain = PlayerParticleSystemInner.main;
            }

            Transform PlayerParticleSystemOuterTransform = Player.transform.Find("PlayerParticleSystemOuter");
            if (PlayerParticleSystemOuterTransform != null)
            {
                PlayerParticleSystemOuter = PlayerParticleSystemOuterTransform.GetComponent<ParticleSystem>();
                PlayerParticleSystemOuterColor = PlayerParticleSystemOuter.main.startColor;
                PlayerParticleSystemOuterMain = PlayerParticleSystemOuter.main;
            }
        }
    }

    private void Update()
    {
        if(FadeWarningSound)
        {
            StartCoroutine(StopWarningSound());
        }
        /*if(WarningFlashActivated && WarningFlashInterval > 0)
        {
            WarningFlashInterval -= .01f;
            if(WarningFlashInterval<0)
            {
                if (WarningColorActive)
                {
                    ChangeParticleColor(PlayerParticleSystemInnerMain, PlayerParticleSystemInnerColor, false);
                    ChangeParticleColor(PlayerParticleSystemOuterMain, PlayerParticleSystemOuterColor, false);
                    WarningFlashInterval = WarningFlashSpeed;
                }
                else
                {
                    ChangeParticleColor(PlayerParticleSystemInnerMain, Color.red, true);
                    ChangeParticleColor(PlayerParticleSystemOuterMain, Color.red, true);
                    WarningFlashInterval = WarningFlashSpeed;
                }
            }
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("The Player will be hit!");
            WarningFlashActivated = true;
            WarningFlashInterval = WarningFlashSpeed;
            ChangeParticleColor(PlayerParticleSystemInnerMain, Color.red, true);
            ChangeParticleColor(PlayerParticleSystemOuterMain, Color.red, true);

            if(WarningSound != null)
            {
                WarningSound.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            WarningFlashActivated = false;
            ChangeParticleColor(PlayerParticleSystemInnerMain, PlayerParticleSystemInnerColor,false);
            ChangeParticleColor(PlayerParticleSystemOuterMain, PlayerParticleSystemOuterColor,false);
            WarningFlashInterval = 0.0f;

            if (WarningSound != null)
            {
                FadeWarningSound = true;
            }
        }
    }

    void ChangeParticleColor(ParticleSystem.MainModule MainParticleSystem, ParticleSystem.MinMaxGradient colorToChangeTo, bool IsWarningColor)
    {
        Debug.Log("Warning color changing");
        WarningColorActive = IsWarningColor;
        MainParticleSystem.startColor = colorToChangeTo;
    }

    IEnumerator StopWarningSound()
    {
        if (WarningSound!=null)
        {
            WarningSound.volume -= 0.1f;
            if(WarningSound.volume <= 0)
            {
                WarningSound.Stop();
                FadeWarningSound = false;
                WarningSound.volume = 1.0f;
            }
        }
        yield return null;
    }
}
