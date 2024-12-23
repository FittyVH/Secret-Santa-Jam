using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InjuredDialogue : MonoBehaviour
{
    [SerializeField] GameObject spaceShip;
    [SerializeField] GameObject[] dialogueIntro;
    [SerializeField] GameObject[] hasMedicineDialogue;

    DoctorDialogue doctorDialogue;

    [SerializeField] GameObject doctor;
    [SerializeField] GameObject pressE;

    bool isColliding = false;
    bool stopShip = false;
    public bool talkedToInjured = false;
    int i = 0;

    void Start()
    {
        doctorDialogue = doctor.GetComponent<DoctorDialogue>();
    }

    void Update()
    {
        if (doctorDialogue.hasMedicine)
        {
            HasMedicineDialogueSystem();
        }
        else
        {
            DialogueIntroSystem();
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
    }

    void StartShip()
    {
        spaceShip.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        spaceShip.GetComponent<SpaceShipController>().enabled = true;
    }

    void DialogueIntroSystem()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            // dialogue system
            if (i == 0 && Input.GetKeyDown(KeyCode.E))
            {
                dialogueIntro[0].SetActive(true);
                i++;
                stopShip = true;
            }
            else if (i > 0 && i < dialogueIntro.Length && Input.GetKeyDown(KeyCode.E))
            {
                dialogueIntro[i].SetActive(true);
                dialogueIntro[i - 1].SetActive(false);
                i++;
            }
            else if (i == dialogueIntro.Length && Input.GetKeyDown(KeyCode.E))
            {
                dialogueIntro[i - 1].SetActive(false); // Safely access the last element
                stopShip = false;
                i = 0;
                talkedToInjured = true;
            }
        }
    }

    void HasMedicineDialogueSystem()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            // dialogue system
            if (i == 0 && Input.GetKeyDown(KeyCode.E))
            {
                hasMedicineDialogue[0].SetActive(true);
                i++;
                stopShip = true;
            }
            else if (i > 0 && i < hasMedicineDialogue.Length && Input.GetKeyDown(KeyCode.E))
            {
                hasMedicineDialogue[i].SetActive(true);
                hasMedicineDialogue[i - 1].SetActive(false);
                i++;
            }
            else if (i == hasMedicineDialogue.Length && Input.GetKeyDown(KeyCode.E))
            {
                hasMedicineDialogue[i - 1].SetActive(false); // Safely access the last element
                stopShip = false;
                i = 0;
                talkedToInjured = true;
            }
        }
    }
}
