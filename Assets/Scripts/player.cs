using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas lose;



    private float movingInput;
    private bool facingRight = true;
    [Header("Move")]
    private bool canWallSlide;
    private bool isWallSliding;
    private bool isHurted;
    private int facingDirection = 1;

    [Header("Collision")]
    [SerializeField] private Transform CheckGround;
    private float GroundCheckRadius = 0.5f;
    [SerializeField] private LayerMask Ground;
    private bool isGround;

    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    private bool isWallDetected;

    [Header("Move")]
    public int pizzaCount;
    [SerializeField] private int Target;
    [SerializeField] private Text counterText;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        //CheckInput();
        AnimatorController();
        CollisionCheck();
        FlipController();
        targetCounter();
        if (lose.gameObject.activeSelf)
            Destroy(gameObject);
    }
    
    private void Flip()
    {
        facingDirection = facingDirection * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if(isGround && isWallDetected)
        {
            if (facingRight && movingInput < 0)
                Flip();
            else if (!facingRight && movingInput > 0)
                Flip();
        }

        if (rb.linearVelocity.x > 0 && !facingRight)
            Flip();
        else if (rb.linearVelocity.x < 0 && facingRight)
            Flip();
    }


    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocity.x != 0;
        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isGround", isGround);
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isWallSliding", isWallSliding);
        anim.SetBool("isHurted", isHurted);
    }

   
    private void FixedUpdate()
    {
        
        if (Input.GetAxis("Vertical") < 0)
            canWallSlide = false;
        if (isWallDetected && canWallSlide)
        {
            isWallSliding = true;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
        else if (!isWallDetected)
        {
            isWallSliding = false;
            
        }
    }

    private void CollisionCheck()
    {
        isGround = Physics2D.OverlapCircle(CheckGround.position, GroundCheckRadius, Ground);
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, Ground);

        if (!isGround && rb.linearVelocity.y < 0)
            canWallSlide = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.z));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            isHurted = true;
            Invoke("Off", 1);
        }
        
        if (collision.tag == "finish")
        {
            if(Target == pizzaCount)
            {
             winCanvas.gameObject.SetActive(true);
             gameObject.SetActive(false);
            }

            for (int i = 2; i <= 12; i++)
            {
                int value = i - 1;
                PlayerPrefs.SetInt(value.ToString(), value);
            }
        }
           

    }
    private void Off()
    {
        isHurted = false;
    }
    private void targetCounter()
    {
        int canpizza = Target - pizzaCount;
        if(canpizza < 0)
        {
            canpizza = 0;
        }
        counterText.text = canpizza.ToString();
    }
}
