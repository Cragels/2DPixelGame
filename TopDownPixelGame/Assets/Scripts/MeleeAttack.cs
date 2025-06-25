using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackPivot;
    public GameObject attackSwing;
    public float attackDuration = 0.5f;
    public LayerMask enemyLayers;
    public float waitAttack = 1f;

    private bool isAttacking = false;

    public bool IsAttacking => isAttacking;

    public float damage = 0f;

    [Header("Ranged Settings")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public float rangedCooldown = 4f;

    [Header("AOE Attack Settings")]
    public GameObject aoeEffectPrefab; // Visual effect for AOE attack
    public float aoeRadius = 3f; // Radius of the AOE attack
    public float aoeDamage = 2f; // Damage dealt by AOE
    public float aoeCooldown = 3f; // Cooldown between AOE attacks
    public float aoeKnockbackForce = 15f; // Force of knockback
    public float aoeExpandDuration = 0.3f; // Time it takes to fully expand
    public KeyCode aoeKey = KeyCode.Q; // Key to trigger AOE attack
    public bool canUseAoe = true;

    public bool canShoot = true;

    [Header("Cooldown Tracking")]
    public float rangedCooldownTimer = 0f;
    public float aoeCooldownTimer = 0f;


    [Header("Slash Animation")]
    public Animator slashAnimator;
    public AnimationClip slashAnimation;
    public float slashAnimationSpeed = 1f;
    public Transform slashSpawnPoint;

    [Header("Shield Settings")]
    public GameObject shieldHitbox; // Assign a circular collider GameObject
    public KeyCode shieldKey = KeyCode.E;
    public float shieldDuration = 5f;
    public float shieldCooldown = 3f;
    public float shieldKnockbackForce = 8f;
    public bool canUseShield = true;
    public float shieldCooldownTimer = 0f;

    //private static EnemyHealth enemyHealth;
    private void Start()
    {
        // Set animation speed
        if (slashAnimator != null && slashAnimation != null)
        {
            slashAnimator.speed = slashAnimationSpeed;
        }
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        attackPivot.rotation = Quaternion.Euler(0, 0, angle);

        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {

            FaceMouse();
            StartCoroutine(PerformAttack());
            if (slashAnimator != null && slashAnimation != null)
            {
                slashAnimator.speed = slashAnimationSpeed;
            }
            new WaitForSeconds(waitAttack);
        }
        if (Input.GetMouseButtonDown(1) && canShoot)
        {
            FaceMouse();
            StartCoroutine(PerformRangedAttack());
            new WaitForSeconds(rangedCooldown);
        }
        if (Input.GetKeyDown(aoeKey) && canUseAoe)
        {
            StartCoroutine(PerformAoeAttack());
        }
        if(Input.GetKeyDown(shieldKey) && canUseShield)
        {
            FaceMouse();
            StartCoroutine(PerformShield());
        }

    }

    private IEnumerator PerformAttack()
    {
        isAttacking = true;

        attackSwing.SetActive(true);

        Collider2D[] results = new Collider2D[10];
        int hitCount = Physics2D.OverlapCollider(
            attackSwing.GetComponent<Collider2D>(),
            new ContactFilter2D { layerMask = enemyLayers, useLayerMask = true },
            results
        );

        for (int i = 0; i < hitCount; i++)
        {
            Collider2D enemy = results[i];
            if (enemy != null)
            {
                Debug.Log("Hit: " + enemy.name);
                // TODO: Deal damage
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
            }
        }


        yield return new WaitForSeconds(attackDuration);
        attackSwing.SetActive(false);
        isAttacking = false;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("hit Enemy");
        }
    }
    */

    private IEnumerator PerformRangedAttack()
    {
        canShoot = false;
        rangedCooldownTimer = rangedCooldown;

        // Aim direction
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - firePoint.position).normalized;

        // Instantiate and shoot
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Projectile prb = projectile.GetComponent<Projectile>();
        prb.SetDirection(direction);

        while (rangedCooldownTimer > 0)
        {
            rangedCooldownTimer -= Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }
    /*
    private IEnumerator PerformAoeAttack()
    {
        canUseAoe = false;
        
        GameObject effect = Instantiate(aoeEffectPrefab, transform.position, Quaternion.identity);

        //float currentRadius = 0f;
        //float expandSpeed = 10f;

        // Create visual effect
        if (aoeEffectPrefab != null)
        {
             effect = Instantiate(aoeEffectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 1f); // Adjust time based on your effect duration
        }

        // Detect enemies in radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, aoeRadius, enemyLayers);



        // Damage all enemies in radius
        foreach (Collider2D enemy in hitEnemies)
        {
            // Assuming enemies have a TakeDamage method in their health component
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(aoeDamage);
            }

            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                enemyRb.AddForce(knockbackDir * 5f, ForceMode2D.Impulse); // Adjust force as needed
            }
        }

        yield return new WaitForSeconds(aoeCooldown);
        canUseAoe = true;
    }
    */

    private IEnumerator PerformAoeAttack()
    {
        canUseAoe = false;
        aoeCooldownTimer = aoeCooldown;

        // Create the AOE effect
        GameObject effect = Instantiate(aoeEffectPrefab, transform.position, Quaternion.identity);
        effect.transform.localScale = Vector3.zero; // Start from zero size

        // Get the SpriteRenderer to modify color if needed
        SpriteRenderer effectRenderer = effect.GetComponent<SpriteRenderer>();
        Color originalColor = effectRenderer != null ? effectRenderer.color : Color.white;

        // Expand the AOE effect over time
        float timer = 0f;
        while (timer < aoeExpandDuration)
        {
            timer += Time.deltaTime;
            float progress = timer / aoeExpandDuration;

            // Scale up the effect
            effect.transform.localScale = Vector3.one * (progress * aoeRadius * 2f);

            // Optional: Fade out the effect as it expands
            if (effectRenderer != null)
            {
                effectRenderer.color = new Color(
                    originalColor.r,
                    originalColor.g,
                    originalColor.b,
                    Mathf.Lerp(1f, 0.5f, progress)
                );
            }

            // Damage enemies in the current radius (damage happens continuously during expansion)
            float currentRadius = progress * aoeRadius;
            DamageEnemiesInRadius(currentRadius);

            yield return null;
        }

        // Ensure final size is correct
        effect.transform.localScale = Vector3.one * (aoeRadius * 2f);

        // Damage enemies one final time at full radius
        DamageEnemiesInRadius(aoeRadius);

        // Fade out and destroy the effect
        float fadeDuration = 0.2f;
        timer = 0f;
        while (timer < fadeDuration && effectRenderer != null)
        {
            timer += Time.deltaTime;
            effectRenderer.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                Mathf.Lerp(0.5f, 0f, timer / fadeDuration)
            );
            yield return null;
        }

        Destroy(effect);

        while (aoeCooldownTimer > 0)
        {
            aoeCooldownTimer -= Time.deltaTime;
            yield return null;
        }
        canUseAoe = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aoeRadius);
    }


    private void DamageEnemiesInRadius(float radius)
    {
        // Detect enemies in current radius
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayers);

        // Damage and knockback all enemies in radius
        foreach (Collider2D enemy in hitEnemies)
        {
            // Only process each enemy once per AOE attack
            if (!enemy.CompareTag("Enemy")) continue;

            // Damage the enemy
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(aoeDamage);
            }

            // Apply knockback
            Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                enemyRb.AddForce(knockbackDir * aoeKnockbackForce, ForceMode2D.Impulse);

                // Optional: Add a small upward force for more dramatic effect
                enemyRb.AddForce(Vector2.up * (aoeKnockbackForce * 0.3f), ForceMode2D.Impulse);
            }
        }
    }

    private IEnumerator PerformShield()
    {
        canUseShield = false;
        shieldCooldownTimer = shieldCooldown;

        // Enable shield visual and hitbox
        shieldHitbox.SetActive(true);

        // Get all enemies in shield range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
            shieldHitbox.transform.position,
            shieldHitbox.GetComponent<CircleCollider2D>().radius,
            enemyLayers
        );

        // Apply knockback to all enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                if (enemyRb != null)
                {
                    Vector2 knockbackDir = (enemy.transform.position - transform.position).normalized;
                    enemyRb.AddForce(knockbackDir * shieldKnockbackForce, ForceMode2D.Impulse);
                }
            }
        }

        // Shield active duration
        yield return new WaitForSeconds(shieldDuration);
        shieldHitbox.SetActive(false);

        // Cooldown
        while (shieldCooldownTimer > 0)
        {
            shieldCooldownTimer -= Time.deltaTime;
            yield return null;
        }

        canUseShield = true;
    }
    private void FaceMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // Optional: Set a small offset from the player
        float attackDistance = 0.5f;
        Vector3 offset = new Vector3(Mathf.Sign(direction.x) * attackDistance, 0, 0);

        // Move the hitbox to the left or right side of the player
        attackSwing.transform.localPosition = offset;

        // Flip the hitbox if needed (optional)
        Vector3 scale = attackSwing.transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (direction.x < 0 ? -1 : 1);
        attackSwing.transform.localScale = scale;
    }

    

}
