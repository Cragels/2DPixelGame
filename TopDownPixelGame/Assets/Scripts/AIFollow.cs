using UnityEngine;

public class AIFollow : MonoBehaviour
{
    private GameObject Player;
    public float Speed;
    public int Range;
    private Rigidbody2D rb;


    private float Distance;

    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;
    public float knockbackDuration = 0.2f;
    public float KnockbackForce = 5f;

    public float AOEKnockbackForce = 5f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.FindWithTag("Player");

        if (Player == null)
        {
            Debug.LogWarning("Player not found in scene. Make sure the Player object is tagged as 'Player'.");
        }
    }

    private void Update()
    {
        if (Player == null) return;


        if (isKnockedBack)
        {
            knockbackTimer -= Time.deltaTime;
            if (knockbackTimer <= 0)
            {
                isKnockedBack = false;
            }
            return; // Skip chasing while knocked back
        }
        /*
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if(Distance < Range)
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
        */

        
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < Range)
        {
            Vector2 direction = (Player.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * Speed * Time.deltaTime);
        }
        
    }

    /*void FixedUpdate()
    {

        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < Range)
        {
            Vector2 direction = (Player.transform.position - transform.position).normalized;
            rb.AddForce(direction * Speed ,ForceMode2D.Force);
        }
        //else
        //{
        //    rb.AddForce(Vector2.zero);
        //}

        float maxSpeed = 3f;
        if (rb.AddForce(magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

    }*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.CompareTag("pAttack"))
        {
            Vector2 knockbackDir = (transform.position - Player.transform.position).normalized;
            rb.AddForce(knockbackDir * KnockbackForce, ForceMode2D.Impulse);
            isKnockedBack = true;
            knockbackTimer = knockbackDuration;
        }
        */
        if (other.CompareTag("pAttack"))
        {
            // Fix 1: Reset velocity
            //rb.linearVelocity = Vector2.zero;

            // Fix 2: Use attack origin (not just player) for direction
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDir * KnockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;
        }
        if (other.CompareTag("AOEattack"))
        {
            // Fix 1: Reset velocity
            //rb.linearVelocity = Vector2.zero;

            // Fix 2: Use attack origin (not just player) for direction
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDir * AOEKnockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;
        }
        if (other.CompareTag("Shield"))
        {
            // Fix 1: Reset velocity
            //rb.linearVelocity = Vector2.zero;

            // Fix 2: Use attack origin (not just player) for direction
            Vector2 knockbackDir = (transform.position - other.transform.position).normalized;

            rb.AddForce(knockbackDir * KnockbackForce, ForceMode2D.Impulse);

            isKnockedBack = true;
            knockbackTimer = knockbackDuration;
        }
    }

}



