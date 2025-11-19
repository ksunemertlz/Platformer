using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [Header("Move")]
    [SerializeField] private float Speed = 5f;
    private float movingInput;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private int maxJumps = 2;
    private int jumpsRemaining;

    [Header("Wall")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    private bool canWallSlide;
    private int facingDirection = 1;
    [SerializeField] private Vector2 wallJumpDirection;

    [Header("GroundCheck")]
    private float GroundCheckRadius = 0.5f;
    [SerializeField] private Transform CheckGround;
    [SerializeField] private LayerMask Ground;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(movingInput * Speed, rb.linearVelocity.y);
        GroundCheck();
        WallCheck();
    }

    public void Move(InputAction.CallbackContext context)
    {
        movingInput = context.ReadValue<Vector2>().x;
    }

    private void GroundCheck()
    {
        if (Physics2D.OverlapCircle(CheckGround.position, GroundCheckRadius, Ground))
        {
            jumpsRemaining = maxJumps;
        }
    }

    private void WallCheck()
    {
        if (Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, Ground))
        {
            canWallSlide = true;
            jumpsRemaining = maxJumps;
            facingDirection = 1; // Update facingDirection when next to right wall
            wallJumpDirection = new Vector2(-wallJumpDirection.x, wallJumpDirection.y);
        }
        else if (Physics2D.Raycast(wallCheck.position, Vector2.left, wallCheckDistance, Ground))
        {
            canWallSlide = true;
            jumpsRemaining = maxJumps;
            facingDirection = -1; // Update facingDirection when next to left wall
            wallJumpDirection = new Vector2(wallJumpDirection.x, wallJumpDirection.y); // Update wallJumpDirection for left wall
        }
        else
        {
            canWallSlide = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (jumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                if (canWallSlide && facingDirection > 0) // ���� �������� ������ � �����
                {
                    Vector2 direction = wallJumpDirection * facingDirection; // ���������� ����������� ������ �� �����
                    rb.linearVelocity = new Vector2(0f, 0f); // �������� �������� ����� �������
                    rb.AddForce(new Vector2(direction.x, jumpForce), ForceMode2D.Impulse); // ��������� ������� � Rigidbody ��� ������ �� �����
                }
                else if (canWallSlide && facingDirection < 0)
                {
                    Vector2 direction = wallJumpDirection * facingDirection; // ���������� ����������� ������ �� �����
                    rb.linearVelocity = new Vector2(0f, 0f); // �������� �������� ����� �������
                    rb.AddForce(new Vector2(direction.x, jumpForce), ForceMode2D.Impulse); // ��������� ������� � Rigidbody ��� ������ �� �����
                }

            }
            else if (context.canceled && rb.linearVelocity.y > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y);
                jumpsRemaining--;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.left * wallCheckDistance);
        Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * wallCheckDistance);
    }
}