using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class NewShipDoor : MonoBehaviour
{
    bool isColliding = false;
    bool puzzleWindowOpen = false;

    public bool hasTuraciumShip = false;

    [SerializeField] GameObject puzzleWindow;
    [SerializeField] GameObject correctPatternWindow;
    [SerializeField] GameObject ship;
    [SerializeField] GameObject pressE;

    [SerializeField] Sprite newShipSprite;
    [SerializeField] Sprite oldShipSprite;

    SpaceShipController spaceShipController;
    Rigidbody2D rbShip;

    void Start()
    {
        spaceShipController = ship.GetComponent<SpaceShipController>();
        rbShip = ship.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
            puzzleWindowOpen = !puzzleWindowOpen;
        }

        if (puzzleWindowOpen)
        {
            puzzleWindow.SetActive(true);
            spaceShipController.enabled = false;
            rbShip.constraints = RigidbodyConstraints2D.FreezePosition;
            pressE.SetActive(false);
        }
        else if (!puzzleWindowOpen)
        {
            puzzleWindow.SetActive(false);
            spaceShipController.enabled = true;
            rbShip.constraints = RigidbodyConstraints2D.None;
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

    public void OnOkayClicked()
    {
        correctPatternWindow.SetActive(false);
        puzzleWindowOpen = false;
        hasTuraciumShip = true;
        ship.GetComponent<SpriteRenderer>().sprite = newShipSprite;
        ship.GetComponent<Light2D>().color = Color.magenta;

        GetComponent<SpriteRenderer>().sprite = oldShipSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
