using UnityEngine;

public class AIFollow : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public int Range;

    private float Distance;

    private void Start()
    {
        
    }

    private void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if(Distance < Range)
        transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
    }


}

