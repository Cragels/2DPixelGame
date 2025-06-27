using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCam : MonoBehaviour
{
    [Header("Camera Movement Settings")]
    [SerializeField] private Camera Cam;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float stoppingDistance = 0.1f;
    //[SerializeField] private AnimationCurve movementCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    [Header("Preset Positions")]
    [SerializeField] public Vector2 topPos;
    [SerializeField] public Vector2 midPos;
    [SerializeField] public Vector2 bottomPos;
    [SerializeField] public Vector2 leftPos;
    [SerializeField] public Vector2 rightPos;

    private Vector2 targetPos;
    private Vector2 startPos;
    //private float movementProgress;
    private bool isMoving = false;

    [SerializeField] private float smoothTime = 0.3f;
    private Vector2 currentVelocity;


    private void Start()
    {

    }

    private void Update()
    {
        /* if (isMoving)
         {
             movementProgress += moveSpeed * Time.deltaTime;
             movementProgress = Mathf.Clamp01(movementProgress);

             float easedProgress = movementCurve.Evaluate(movementProgress);

             Cam.transform.position = Vector2.Lerp(startPos, targetPos, easedProgress);

             if (movementProgress >= 1f || Vector2.Distance(Cam.transform.position, targetPos) < stoppingDistance)
             {
                 Cam.transform.position = targetPos;
                 isMoving = false;
             }
         }


        Cam.transform.position = Vector2.SmoothDamp(transform.position, targetPos, ref currentVelocity, smoothTime);


        if (Vector2.Distance(transform.position, targetPos) < stoppingDistance)
        {
            transform.position = targetPos;
            isMoving = false;
        }*/


        if (!isMoving || Cam == null)
            return;

        Vector3 currentCamPos = Cam.transform.position;
        Vector2 cam2D = new Vector2(currentCamPos.x, currentCamPos.y);

        float adjustedSmoothTime = smoothTime / moveSpeed; // Higher speed = lower smooth time

        cam2D = Vector2.SmoothDamp(cam2D, targetPos, ref currentVelocity, adjustedSmoothTime);

        Cam.transform.position = new Vector3(cam2D.x, cam2D.y, currentCamPos.z);

        if (Vector2.Distance(cam2D, targetPos) < stoppingDistance)
        {
            Cam.transform.position = new Vector3(targetPos.x, targetPos.y, currentCamPos.z);
            isMoving = false;
        }
    }


    public void Move()
    {
        //movementProgress = 0f;
        isMoving = true;
    }

    public void MoveTop()
    {
        Debug.Log("MoveTop triggered");
        startPos = midPos;
        targetPos = topPos;
        Move();
    }

    public void MoveBottom()
    {
        startPos = midPos;
        targetPos = bottomPos;
        Move();
    }

    public void MoveUpMid()
    {
        startPos = bottomPos;
        targetPos = midPos;
        Move();
    }

    public void MoveDownMid()
    {
        startPos = topPos;
        targetPos = midPos;
        Move();
    }

    public void MoveLeft()
    {
        startPos = midPos;
        targetPos = leftPos;
        Move();
    }

    public void MoveRightMid()
    {
        startPos = leftPos;
        targetPos = midPos;
        Move();
    }

    public void MoveRight()
    {
        startPos = midPos;
        targetPos = rightPos;
        Move();
    }


    public void MoveLeftMid()
    {
        startPos = rightPos;
        targetPos = midPos;
        Move();
    }

}
