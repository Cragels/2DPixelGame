using UnityEngine;
using UnityEngine.Splines;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody2D rb;
    public float MaxHealth = 4f;
    float Health;

    public float swordDam = 3f;
    public float bowDam = 3f;
    public float hamDam = 4f;


    [SerializeField] FloatingHealthBar healthbar;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        healthbar = GetComponentInChildren<FloatingHealthBar>();
    }

    void Start()
    {
        Health = MaxHealth;
        //healthbar.UpdateHealthBar(Health, MaxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Boss took damage: {damageAmount}");
        Health -= damageAmount;
        healthbar.UpdateHealthBar(Health, MaxHealth);
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //BossManager.isAlive = false;
        Destroy(rb.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "pAttack")
        {
            /*
            //if (isAlive)
            //{

                //isAlive = false;
                //animator.SetTrigger("Dead");

                // hitbox.enabled = false;
               // rb.linearVelocity = Vector2.zero;
               // rb.bodyType = RigidbodyType2D.Static;



                //Invoke(nameof(FreezeAnimation), 2f);

           // }

            //DeactivateHitBox();
            */
            TakeDamage(swordDam);

        }
        if(collision.gameObject.tag == "rAttack")
        {
            TakeDamage(bowDam);
        }
    }

}
