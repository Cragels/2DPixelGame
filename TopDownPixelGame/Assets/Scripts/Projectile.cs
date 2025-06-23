using UnityEngine;

public class Projectile : MonoBehaviour
{

        public float speed = 15f;
        public float lifetime = 2f;
        public float damage = 1f;

        private Vector2 direction;
        Rigidbody2D rb;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        if (rb != null)
            rb.linearVelocity = direction * speed;

        //transform.rotation = Quaternion.Euler(0f, 0f, 180f);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        Destroy(gameObject, lifetime);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

        private void Update()
        {
           SetDirection(direction);
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("Projectile hit " + other.name);
                // TODO: Apply damage to enemy here
                Destroy(gameObject);
            }
            if (other.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
    }
