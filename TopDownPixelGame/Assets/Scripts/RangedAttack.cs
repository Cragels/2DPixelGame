using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float cooldown = 1f;

    private float lastShotTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Time.time >= lastShotTime + cooldown)
        {
            ShootProjectile();
            lastShotTime = Time.time;
        }
    }

    private void ShootProjectile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDirection = (mousePos - firePoint.position).normalized;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        proj.GetComponent<Projectile>().SetDirection(shootDirection);
    }
}
