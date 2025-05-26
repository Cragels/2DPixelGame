using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Rigidbody2D rb;
    float MaxHealth = 10f;
    float Health;

    [SerializeField] PlayerHealthBar playerHealthbar;


    private void Awake()
    {

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //characterHealthbar = GetComponentInChildren<CharacterHealthBar>();
        Health = MaxHealth;
        //healthbar.UpdateHealthBar(Health, MaxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        Debug.Log($"Boss took damage: {damageAmount}");
        Health -= damageAmount;
        playerHealthbar.UpdateHealthBar(Health, MaxHealth);
        if (Health <= 0)
        {
           // Destroy();

        }
    }

    public void Destroy()
    {
        //BossManager.isAlive = false;
        Destroy(transform.parent.gameObject);
    }
}
