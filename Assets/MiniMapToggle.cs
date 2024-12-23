using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapToggle : MonoBehaviour
{
    [SerializeField] GameObject miniMapUI;

    bool mapOpen = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapOpen = !mapOpen;
        }

        if (mapOpen)
        {
            miniMapUI.SetActive(true);
        }
        else
        {
            miniMapUI.SetActive(false);
        }
    }
}
