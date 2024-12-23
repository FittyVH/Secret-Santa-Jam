using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnterAtmosphere : MonoBehaviour
{
    public bool insdiePlanet = false;

    Transform currentPlanet;

    [SerializeField] GameObject pressQ;
    [SerializeField] GameObject pressSpace;

    Rigidbody2D rb;
    [SerializeField] GameObject compass;

    [SerializeField] float gravityStrength;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (insdiePlanet)
        {
            // look at that planet
            Vector2 lookDirection = (transform.position - currentPlanet.position).normalized;

            // calculate the tan inverse of (lookDirection.y/lookDirection.x) to find its angle with x axis
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            rb.rotation = lookAngle - 90f;

            // add gravity
            Vector2 gravityForce = -lookDirection * 5f;
            rb.AddForce(gravityForce);

            // enable prompts
            pressQ.SetActive(true);
            pressSpace.SetActive(true);

            // compass look at planet
            compass.GetComponent<Rigidbody2D>().rotation = lookAngle - 90f;
        }
        else
        {
            pressQ.SetActive(false);
            pressSpace.SetActive(false);
            compass.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Atmosphere")
        {
            insdiePlanet = true;
            currentPlanet = other.transform.parent;
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Atmosphere")
        {
            insdiePlanet = false;
            other.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
