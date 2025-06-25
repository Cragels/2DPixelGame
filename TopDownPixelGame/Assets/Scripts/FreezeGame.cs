using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isAlive == false)
        {
            Time.timeScale = 0f;
        }
    }
}
