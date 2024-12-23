using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FruitPickUp : MonoBehaviour
{
    // bools
    bool isColliding = false;

    // scripts
    DoctorDialogue doctorDialogue;

    // objects
    [SerializeField] GameObject doctor;
    [SerializeField] GameObject pressEPrompt;
    [SerializeField] GameObject hasFruitPrompt;

    void Start()
    {
        doctorDialogue = doctor.GetComponent<DoctorDialogue>();
    }

    void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            doctorDialogue.newHasFruit = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Light2D>().enabled = false;
            hasFruitPrompt.SetActive(true);
            Invoke(nameof(DisableHasFruitPrompt), 3f);
            Debug.Log("picked");
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

    void DisableHasFruitPrompt()
    {
        hasFruitPrompt.SetActive(false);
    }
}
