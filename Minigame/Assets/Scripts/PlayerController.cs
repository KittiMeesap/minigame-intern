using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 playerMove;
    public float playerSpeed = 5f;

    private bool isMoving;
    private bool isHitWall;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove.x = Input.GetAxis("Horizontal");
        playerMove.z = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = playerMove.normalized * playerSpeed;
    }

}
