using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    private Vector2 input;

    public Animator animator;

    float _move;

    private bool canMove = true;

    private bool isAlive = true;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
        

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);


    }
    void Update()
    {
        HandleInput();
        SpriteControl();
        /*
        if (canMove)
        {
            MoveSprite(_move);

            _move = Input.GetAxis("Horizontal");
            if (Mathf.Abs(_move) > 0)
            {
                animator.SetFloat("move", Mathf.Abs(_move));


            }
            if (Mathf.Abs(_move) == 0)
            {
                animator.SetFloat("move", 0f);


            }
        }
       */
    }

    void HandleInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;
    }

    private void MoveSprite(float direction)
    {
        if(canMove)
        {
            rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        }
       


    }

    private void SpriteControl()
    {
        if (canMove)
        {
            if (input.x != 0)
            {
                //spriteRenderer.flipX = input.x < 0;
                if (Input.GetAxis("Horizontal") < 0)
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                if (Input.GetAxis("Horizontal") > 0)
                    transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}
