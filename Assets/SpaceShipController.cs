using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    Rigidbody2D rb;
    EnterAtmosphere enterAtmosphere;

    [SerializeField] GameObject thrustSprite;
    [SerializeField] AudioSource shipAudioSrc;
    [SerializeField] AudioClip thrustAudio;

    public float speed = 10f;
    public float upThrust = 100f;
    public float planetaryDrag = 2f;

    bool startThrustAudio = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enterAtmosphere = GetComponent<EnterAtmosphere>();
    }

    void Update()
    {
        if (enterAtmosphere.insdiePlanet)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(transform.TransformDirection(Vector2.up) * upThrust, ForceMode2D.Force);
                thrustSprite.SetActive(true);
                startThrustAudio = true;
            }
            else
            {
                thrustSprite.SetActive(false);
                startThrustAudio = false;
            }
            rb.drag = planetaryDrag;

            // thrust audio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shipAudioSrc.clip = thrustAudio;
                shipAudioSrc.loop = true;
                shipAudioSrc.Play();
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                shipAudioSrc.Stop();
                shipAudioSrc.loop = false;
            }
        }
        else
        {
            thrustSprite.SetActive(false);
            rb.drag = 0f;

            shipAudioSrc.Stop();
            shipAudioSrc.loop = false;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY);

        Vector2 worldMoveDirection = transform.TransformDirection(moveDirection);

        rb.AddForce(worldMoveDirection * speed, ForceMode2D.Force);

        if (!enterAtmosphere.insdiePlanet)
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
