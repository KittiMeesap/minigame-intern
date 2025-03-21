using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerDirection = Vector3.zero;
    public float playerSpeed = 10f;

    private bool isMoving = false;
    private bool isHitWall = false;
    private bool isHitDoor = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHitWall)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                WhenPlayerMove(Vector3.forward);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                WhenPlayerMove(Vector3.back);
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
        if (col.gameObject.CompareTag("Wall") || col.gameObject.CompareTag("Door") && !isHitDoor)
        {
            rb.linearVelocity = Vector3.zero;
            isMoving = false;
            isHitWall = true;

            StartCoroutine(AfterHitWall());
        }
    }

    private IEnumerator AfterHitWall()
    {
        yield return new WaitForSeconds(0.3f);

        isHitWall = false;
    }


    private void WhenPlayerMove(Vector3 direction)
    {
        if (isHitWall) return;

        playerDirection = direction;
        isMoving = true;
    }

    public void ResetPlayerPositon(Vector3 checkpointPositon)
    {
        transform.position = checkpointPositon;
        rb.linearVelocity = Vector3.zero;
        isMoving = false;
    }

}
