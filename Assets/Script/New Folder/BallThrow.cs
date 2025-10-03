using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BallThrow : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public GameObject ballPrefab;
    private GameObject ballInstance;
    public float gravity = 9.81f;
    public float initialVelocity = 10f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Update()
    {
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);
        //    Vector2 touchPosition = touch.position;

        //    // Raycast to get the point on the AR plane
        //    Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Create ball at initial touch point
        //        if (ballInstance == null)
        //        {
        //            ballInstance = Instantiate(ballPrefab, hit.point, Quaternion.identity);
        //            initialPosition = ballInstance.transform.position;
        //        }

        //        // Calculate the drag direction
        //        if (touch.phase == TouchPhase.Moved)
        //        {
        //            Vector3 dragDirection = hit.point - initialPosition;
        //            targetPosition = hit.point;
        //            SetTrajectory(dragDirection);
        //        }
        //    }
        //}

        // For Editor testing, use mouse input as a simulation for touch
        if (Application.isEditor && Input.GetMouseButton(0)) // Left-click to simulate touch
        {
            
            Vector2 touchPosition = Input.mousePosition;

            // Raycast to get the point on the AR plane (or simulate a raycast in Editor)
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Instantiate ball at the hit point if it is not already instantiated
                if (ballInstance == null)
                {
                    ballInstance = Instantiate(ballPrefab, hit.point, Quaternion.identity);
                    initialPosition = ballInstance.transform.position;
                }

                // Calculate the ball's trajectory based on drag or touch movement
                Vector3 dragDirection = hit.point - initialPosition;
                SetTrajectory(dragDirection);
            }
        }
    }

    void SetTrajectory(Vector3 dragDirection)
    {
        // Calculate the launch velocity and angle from drag direction
        float distance = dragDirection.magnitude;
        Vector3 velocity = dragDirection.normalized * initialVelocity;

        // Add a simple parabolic effect using physics
        Rigidbody rb = ballInstance.GetComponent<Rigidbody>();
        rb.velocity = velocity;
        rb.useGravity = true;
    }
}
