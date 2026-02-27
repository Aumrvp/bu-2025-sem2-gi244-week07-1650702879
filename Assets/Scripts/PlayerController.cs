using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    public bool isGameOver = false;

    private Rigidbody rb;
    private InputAction jumpAction;
    private bool isOnGround = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Start()
    {
        Physics.gravity = new Vector3(0, -9.81f * gravityMultiplier, 0);
    }

    void Update()
    {
        if (jumpAction.triggered && isOnGround == true && isGameOver == false)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GAME OVER");
            isGameOver = true;
        }
    }
}