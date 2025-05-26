using UnityEngine;

public class AIFollow : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public int Range;
    private Rigidbody2D rb;

    private float Distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if(Distance < Range)
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
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
}



