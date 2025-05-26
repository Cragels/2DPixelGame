using UnityEngine;
using UnityEngine.Splines;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody2D rb;
    float MaxHealth = 4f;
    float Health;

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
            Destroy();
        }
    }

    public void Destroy()
    {
        //BossManager.isAlive = false;
        Destroy(transform.parent.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
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
        }
    }
}
