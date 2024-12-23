using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY);

        Vector2 worldMoveDirection = transform.TransformDirection(moveDirection);

        rb.AddForce(worldMoveDirection * speed, ForceMode2D.Force);
    }
}
