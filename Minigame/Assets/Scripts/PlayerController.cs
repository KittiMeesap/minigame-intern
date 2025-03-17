using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerDirection = Vector3.zero;
    public float playerSpeed = 10f;

    private bool isMoving = false;
    private bool isHitWall = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving || isHitWall)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                WhenPlayerMove(Vector3.forward);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                WhenPlayerMove(Vector3.down);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                WhenPlayerMove(Vector3.left);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                WhenPlayerMove(Vector3.right);
            }
        }
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
            isHitWall = true;
            StartCoroutine(ResetAfterHit());
        }
    }

    private IEnumerator ResetAfterHit()
    {
        while (isHitWall)
        {
            yield return new WaitForSeconds(0.1f);

            isHitWall = false;
        }
    }


    private void WhenPlayerMove(Vector3 direction)
    {
        if (isHitWall) return;
        playerDirection = direction;
        isMoving = true;
        isHitWall = false;
    }

}
