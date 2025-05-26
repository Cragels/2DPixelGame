using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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

    private PlayerHealth playerHealth;

    private float damageCooldown = 0.5f;  
    private float lastDamageTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {

        playerHealth = GetComponent<PlayerHealth>();

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
        
        /*
        if (Input.GetKey(KeyCode.LeftShift))
        {

        }
        */
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

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy") && isAlive) // old way collision.gameObject.tag == "Enemy")

        {
            if (isAlive)
            {

                playerHealth.TakeDamage(2);
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
}
