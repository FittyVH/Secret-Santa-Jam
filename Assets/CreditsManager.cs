using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] GameObject blackScreen;
    [SerializeField] SpaceShipController spaceShipController;

    [SerializeField] AudioSource cameraSrc;
    [SerializeField] AudioClip creditsClip;

    void Start()
    {
        blackScreen.SetActive(true);
        spaceShipController.enabled = false;

        Invoke(nameof(StartCredits), 4f);
    }

    void Update()
    {
        
    }

    void StartCredits()
    {
        cameraSrc.clip = creditsClip;
        cameraSrc.Play();
        cameraSrc.loop = true;
        
        blackScreen.SetActive(false);
        spaceShipController.enabled = true;
    }
}
