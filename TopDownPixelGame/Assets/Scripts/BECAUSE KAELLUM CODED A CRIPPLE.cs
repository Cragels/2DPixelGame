using UnityEngine;

public class BECAUSEKAELLUMCODEDACRIPPLE : MonoBehaviour
{
    private Animator animator; 
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        animator.SetBool("IsRunning", isMoving);
    }

    
}
