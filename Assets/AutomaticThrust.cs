using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutomaticThrust : MonoBehaviour
{
    [SerializeField] FinalProtagonistDialogue finalProtagonistDialogue;
    [SerializeField] SpaceShipController spaceShipController;
    [SerializeField] EnterAtmosphere enterAtmosphere;

    [SerializeField] GameObject thrustSprite;
    [SerializeField] GameObject dogSprite;

    [SerializeField] AudioClip thrustAudio;

    public float speed = 10f;
    int currentIndex;

    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    void Update()
    {
        if (finalProtagonistDialogue.hasLexi)
        {
            dogSprite.SetActive(false);
            spaceShipController.enabled = false;
            spaceShipController.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector2.up) * speed, ForceMode2D.Force);

            if (enterAtmosphere.insdiePlanet)
            {
                thrustSprite.SetActive(true);
            }
            else
            {
                thrustSprite.SetActive(false);
            }

            Invoke(nameof(LoadCredits), 10f);
        }
    }

    void LoadCredits()
    {
        SceneManager.LoadScene(currentIndex + 1);
    }
}
