using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProtagonistDialogue : MonoBehaviour
{
    [SerializeField] GameObject[] inventorDialogue;
    [SerializeField] GameObject pressE;
    [SerializeField] GameObject spaceShip;
    [SerializeField] GameObject blackScreen;

    [SerializeField] EnterAtmosphere enterAtmosphere;

    [SerializeField] AudioSource cameraSrc;
    [SerializeField] AudioSource shipAudioSrc;

    int i = 0;
    bool isColliding = false;
    bool stopShip = false;
    public bool hasLexi = false;

    void Start()
    {
        
    }

    void Update()
    {
        InventorDialogueSystem();

        if (!enterAtmosphere.insdiePlanet)
        {
            shipAudioSrc.Stop();
        }

        if (stopShip)
        {
            StopShip();
        }
        else
        {
            StartShip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ship")
        {
            isColliding = true;
            pressE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ship")
        {
            isColliding = false;
            pressE.SetActive(false);
        }
    }

    void StopShip()
    {
        spaceShip.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        spaceShip.GetComponent<SpaceShipController>().enabled = false;
        Debug.Log("stop");
    }

    void StartShip()
    {
        spaceShip.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        spaceShip.GetComponent<SpaceShipController>().enabled = true;
    }

    void InventorDialogueSystem()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            // dialogue system
            if (i == 0 && Input.GetKeyDown(KeyCode.E))
            {
                cameraSrc.clip = null;
                pressE.SetActive(false);
                inventorDialogue[0].SetActive(true);
                i++;
                stopShip = true;
                blackScreen.SetActive(true);
            }
            else if (i > 0 && i < inventorDialogue.Length && Input.GetKeyDown(KeyCode.E))
            {
                inventorDialogue[i].SetActive(true);
                inventorDialogue[i - 1].SetActive(false);
                i++;
            }
            else if (i == inventorDialogue.Length && Input.GetKey(KeyCode.E))
            {
                inventorDialogue[i - 1].SetActive(false); // Safely access the last element
                stopShip = false;
                i = 0;
                blackScreen.SetActive(false);
                GetComponent<BoxCollider2D>().enabled = false;
                hasLexi = true;
                shipAudioSrc.Play();
                shipAudioSrc.loop = true;
            }
        }
    }
}
