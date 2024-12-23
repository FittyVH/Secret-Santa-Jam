using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] NewShipDoor newShipDoor;

    bool canTeleport = false;

    int currentSceneIndex;

    void Start()
    {
        
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enable Port" && newShipDoor.hasTuraciumShip)
        {
            canTeleport = true;
        }

        if (other.gameObject.tag == "Disable Port" && newShipDoor.hasTuraciumShip)
        {
            canTeleport = false;
        }

        if (other.gameObject.tag == "Port" && canTeleport)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
