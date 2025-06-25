using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Rigidbody2D rb;
    public float MaxHealth = 10f;
    float Health;

    [SerializeField] PlayerHealthBar playerHealthbar;

    PlayerController controller;
    MeleeAttack attack;

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
            Die();

        }
    }

    public void Die()
    {
        controller.isAlive = false;
        attack.canShoot = false;
        attack.canUseAoe = false;
        //attack.isAttacking = false;


    }

    public void ResetHealth()
    {
        Health = MaxHealth;

    }
}
