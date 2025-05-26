using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Rigidbody2D rb;
    float MaxHealth = 10f;
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
}
