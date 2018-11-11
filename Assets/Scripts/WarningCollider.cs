using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningCollider : MonoBehaviour
{
    private GameObject Player;
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

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");

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
        }
    }

    void ChangeParticleColor(ParticleSystem.MainModule MainParticleSystem, ParticleSystem.MinMaxGradient colorToChangeTo, bool IsWarningColor)
    {
        Debug.Log("Warning color changing");
        WarningColorActive = IsWarningColor;
        MainParticleSystem.startColor = colorToChangeTo;
    }
}
