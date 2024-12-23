using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightsShip : MonoBehaviour
{
    Light2D light2D;
    bool lightIsOn = true;

    void Start()
    {
        light2D = GetComponent<Light2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            lightIsOn = !lightIsOn;
        }

        if (lightIsOn)
        {
            light2D.enabled = true;
        }
        else
        {
            light2D.enabled = false;
        }
    }
}
