using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ship")
        {
            Debug.Log("quit game");
            Application.Quit();
        }
    }
}
