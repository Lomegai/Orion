using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    private float moveInput;
    private bool jumpPressed;
    private bool crouchPressed;
    private bool dashPressed;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleMovement();
        HandleJump();
    }

    void HandleInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        jumpPressed = Input.GetKeyDown(KeyCode.Space);

        crouchPressed = Input.GetKey(KeyCode.S);

        dashPressed = Input.GetKeyDown(KeyCode.LeftShift);
    }

    void HandleMovement()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        //if (moveInput != 0) { spriteRenderer.flipX = moveInput < 0; }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleJump()
    {
        if (jumpPressed && isGrounded) {rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);}

        jumpPressed = false;
    }


}
