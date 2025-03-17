using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerDirection = Vector3.zero;
    public float playerSpeed = 10f;

    private bool isMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.linearVelocity = playerDirection * playerSpeed;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Wall" || col.gameObject.CompareTag("Wall"))
        {
            rb.linearVelocity = Vector3.zero;
            isMoving = false;
        }
    }

    private void PlayerInput()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                playerDirection = Vector3.forward;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                playerDirection = Vector3.down;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                playerDirection = Vector3.left;
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                playerDirection = Vector3.right;
                isMoving = true;
            }
        }

    }

}
