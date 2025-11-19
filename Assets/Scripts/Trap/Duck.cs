using UnityEngine;

public class Duck : Trap
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float idleTime = 2;
    private float idleTimeCounter;

    [Header("Collision Info")]
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask isGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;

    private bool wallDetected;
    private bool groundDetected;
    private int facingDirection = -1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        anim.SetFloat("xVelocity", rb.linearVelocity.x);
        CollisionCheck();

        idleTimeCounter -= Time.deltaTime;

        if (idleTimeCounter < 0)
            rb.linearVelocity = new Vector2(moveSpeed * facingDirection, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, 0);

        if(wallDetected || !groundDetected)
        {
            Flip();
            idleTimeCounter = idleTime;
        }
    }

    private void Flip()
    {
        facingDirection = facingDirection * -1;
        transform.Rotate(0, 180, 0);
    }

    private void CollisionCheck()
    {
        wallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, wallCheckDistance, isGround);
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, isGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x * wallCheckDistance * facingDirection, wallCheck.position.y)); ;
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
