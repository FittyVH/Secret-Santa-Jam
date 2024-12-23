using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPrompt : MonoBehaviour
{
    [SerializeField] GameObject voidPrompt;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enable VoidPrompt")
        {
            voidPrompt.SetActive(true);
        }
        if (other.gameObject.tag == "Disable VoidPrompt")
        {
            voidPrompt.SetActive(false);
        }
    }
}
