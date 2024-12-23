using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAtPlanet : MonoBehaviour
{
    [SerializeField] Transform planet;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 lookDirection = (transform.position - planet.position).normalized;

        // calculate the tan inverse of (lookDirection.y/lookDirection.x) to find its angle with x axis
        float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = lookAngle;
    }
}
