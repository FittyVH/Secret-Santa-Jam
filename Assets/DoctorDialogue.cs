using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorDialogue : MonoBehaviour
{
    [SerializeField] GameObject spaceShip;
    [SerializeField] GameObject[] dialogue;
    [SerializeField] GameObject[] dialogueTwo;
    [SerializeField] GameObject[] hasFruitDialogue;

    [SerializeField] GameObject pressEPrompt;

    // script reference 
    InjuredDialogue injuredDialogue;
    FruitPickUp fruitPickUp;

    // script object reference
    [SerializeField] GameObject injuredGuy;
    [SerializeField] GameObject fruit;

    bool isColliding = false;
    bool stopShip = false;
    public bool newHasFruit = false;
    public bool hasMedicine = false;
    int i = 0;

    void Start()
    {
        injuredDialogue = injuredGuy.GetComponent<InjuredDialogue>();
        fruitPickUp = fruit.GetComponent<FruitPickUp>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
            if (newHasFruit)
            {
                HasFruitDialogueSystem();
                Debug.Log("trueeeeeeeeeeeeeeeee");
            }
            else if (!injuredDialogue.talkedToInjured && !newHasFruit)
            {
                DialogueIntroSystem();
            }
            else if (injuredDialogue.talkedToInjured && !newHasFruit)
            {
                DialogueTwoSystem();
            }
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
            pressEPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ship")
        {
            isColliding = false;
            pressEPrompt.SetActive(false);
        }
    }

    void StopShip()
    {
        spaceShip.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        spaceShip.GetComponent<SpaceShipController>().enabled = false;
    }

    void StartShip()
    {
        spaceShip.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        spaceShip.GetComponent<SpaceShipController>().enabled = true;
    }

    void DialogueIntroSystem()
    {
        // dialogue system
        if (i == 0 && Input.GetKeyDown(KeyCode.E))
        {
            dialogue[0].SetActive(true);
            i++;
            stopShip = true;
        }
        else if (i > 0 && i < dialogue.Length && Input.GetKeyDown(KeyCode.E))
        {
            dialogue[i].SetActive(true);
            dialogue[i - 1].SetActive(false);
            i++;
        }
        else if (i == dialogue.Length && Input.GetKeyDown(KeyCode.E))
        {
            dialogue[i - 1].SetActive(false);
            stopShip = false;
            i = 0;
        }
    }

    void DialogueTwoSystem()
    {
        // dialogue system
        if (i == 0 && Input.GetKeyDown(KeyCode.E))
        {
            dialogueTwo[0].SetActive(true);
            i++;
            stopShip = true;
        }
        else if (i > 0 && i < dialogueTwo.Length && Input.GetKeyDown(KeyCode.E))
        {
            dialogueTwo[i].SetActive(true);
            dialogueTwo[i - 1].SetActive(false);
            i++;
        }
        else if (i == dialogueTwo.Length && Input.GetKeyDown(KeyCode.E))
        {
            dialogueTwo[i - 1].SetActive(false);
            stopShip = false;
            i = 0;
        }
    }

    void HasFruitDialogueSystem()
    {
        // dialogue system
        if (i == 0 && Input.GetKeyDown(KeyCode.E))
        {
            hasFruitDialogue[0].SetActive(true);
            i++;
            stopShip = true;
        }
        else if (i > 0 && i < hasFruitDialogue.Length && Input.GetKeyDown(KeyCode.E))
        {
            hasFruitDialogue[i].SetActive(true);
            hasFruitDialogue[i - 1].SetActive(false);
            i++;
        }
        else if (i == hasFruitDialogue.Length && Input.GetKeyDown(KeyCode.E))
        {
            hasFruitDialogue[i - 1].SetActive(false);
            stopShip = false;
            i = 0;
            hasMedicine = true;
        }
    }
}
