using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;
    private Vector2 input;

    public Animator animator;

    float _move;

    //private bool canMove = true;

    public bool isAlive = true;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;

    private PlayerHealth playerHealth;

    private float damageCooldown = 0.5f;  
    private float lastDamageTime;

    private MeleeAttack meleeAttack;

    public float enemyDMG = 2f;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        meleeAttack = GetComponent<MeleeAttack>();
    }
    void Start()
    {

        playerHealth = GetComponent<PlayerHealth>();

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        if (isAlive)
        rb.MovePosition(rb.position + input * moveSpeed * Time.fixedDeltaTime);


    }
    void Update()
    {
        if (isAlive)
        {
            HandleInput();
            SpriteControl();
        }
        
        
        
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
        

        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
        */
    }

    private void SetFacing(bool faceRight)
    {
        if (facingRight != faceRight)
        {
            facingRight = faceRight;
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (facingRight ? 1 : -1);
            transform.localScale = scale;
        }
    }
    /*
    private void FlipSpriteOffMovement()
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
    */
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && isAlive) // old way collision.gameObject.tag == "Enemy")

        {
            if (isAlive)
            {

                playerHealth.TakeDamage(enemyDMG);
                lastDamageTime = Time.time;

                //isAlive = false;
                //animator.SetTrigger("Dead");

                // hitbox.enabled = false;
                //rb.linearVelocity = Vector2.zero;
                //rb.bodyType = RigidbodyType2D.Static;


                //Invoke(nameof(FreezeAnimation), 2f);

            }

            //DeactivateHitBox();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && isAlive)
        {
            if (Time.time - lastDamageTime > damageCooldown)
            {
                playerHealth.TakeDamage(2); 
                lastDamageTime = Time.time;
            }
        }
    }
    void FlipSpriteTowardMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Check if mouse is to the left or right of the player
        if (mousePos.x < transform.position.x)
        {
            // Face left
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Face right
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void SpriteControl()
    {
        if (meleeAttack.IsAttacking)
        {
            //FlipSpriteTowardMouse();
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SetFacing(mousePos.x > transform.position.x);
        }
        
        else
        {
            
            float horizontal = Input.GetAxisRaw("Horizontal");
            if (horizontal != 0)
                SetFacing(horizontal > 0);
        }
            
    }
}
