using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public Transform attackPivot;
    public GameObject attackSwing;
    public float attackDuration = 0.5f;
    public LayerMask enemyLayers;
    public float waitAttack = 1f;

    private bool isAttacking = false;

    public bool IsAttacking => isAttacking;

    public float damage = 0;

    

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
            new WaitForSeconds(waitAttack);
        }

        
    }

    private System.Collections.IEnumerator PerformAttack()
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
