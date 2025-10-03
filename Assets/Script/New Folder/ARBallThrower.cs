using UnityEngine;

public class ARBallThrower : MonoBehaviour
{
    public GameObject ballPrefab;         // Assign your ball prefab here
    public Transform spawnPoint;         // The point where the ball spawns
    public Transform arCameraTransform;  // Assign the AR Camera's Transform
    public LineRenderer trajectoryRenderer; // Assign a LineRenderer for trajectory visualization
    public float throwForceMultiplier = 10f;
    public float maxDragDistance = 200f; // Maximum allowed drag distance


    private Vector2 dragStart;
    private Vector2 dragEnd;

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                dragStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                dragEnd = touch.position;
                VisualizeTrajectory();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                dragEnd = touch.position;
                ThrowBall();
                trajectoryRenderer.positionCount = 0;  // Clear the trajectory
            }
        }
    }

    void VisualizeTrajectory()
    {
        Vector2 dragDirection = dragStart - dragEnd;

        // Calculate the force direction relative to the AR camera
        Vector3 forwardDirection = arCameraTransform.forward.normalized;
        Vector3 rightDirection = arCameraTransform.right.normalized;

        // Combine drag components into a world-space force
        Vector3 force = forwardDirection * dragDirection.y + rightDirection * dragDirection.x;
        force *= throwForceMultiplier;

        trajectoryRenderer.positionCount = 30;

        Vector3 startPoint = spawnPoint.position;
        Vector3 velocity = force / ballPrefab.GetComponent<Rigidbody>().mass;

        for (int i = 0; i < 30; i++)
        {
            float time = i * 0.1f;
            Vector3 point = startPoint + velocity * time + 0.5f * Physics.gravity * time * time;
            trajectoryRenderer.SetPosition(i, point);
        }


        //Vector2 dragDirection = dragStart - dragEnd;

        //// Clamp drag distance to avoid excessive force
        //float dragMagnitude = Mathf.Clamp(dragDirection.magnitude, 0, maxDragDistance);
        //Vector2 clampedDrag = dragDirection.normalized * dragMagnitude;

        //// Calculate the force direction relative to the AR camera
        //Vector3 forwardDirection = arCameraTransform.forward.normalized;
        //Vector3 rightDirection = arCameraTransform.right.normalized;

        //// Combine clamped drag components into a world-space force
        //Vector3 force = forwardDirection * clampedDrag.y + rightDirection * clampedDrag.x;
        //force *= throwForceMultiplier;

        //trajectoryRenderer.positionCount = 30;

        //Vector3 startPoint = spawnPoint.position;
        //Vector3 velocity = force / ballPrefab.GetComponent<Rigidbody>().mass;

        //for (int i = 0; i < 30; i++)
        //{
        //    float time = i * 0.1f;
        //    Vector3 point = startPoint + velocity * time + 0.5f * Physics.gravity * time * time;
        //    trajectoryRenderer.SetPosition(i, point);
        //}
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        // Calculate the force direction relative to the AR camera
        Vector2 dragDirection = dragStart - dragEnd;
        Vector3 forwardDirection = arCameraTransform.forward.normalized;
        Vector3 rightDirection = arCameraTransform.right.normalized;

        Vector3 force = forwardDirection * dragDirection.y + rightDirection * dragDirection.x;
        force *= throwForceMultiplier;

        rb.AddForce(force, ForceMode.Impulse);



        //GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        //Rigidbody rb = ball.GetComponent<Rigidbody>();

        //Vector2 dragDirection = dragStart - dragEnd;

        //// Clamp drag distance to avoid excessive force
        //float dragMagnitude = Mathf.Clamp(dragDirection.magnitude, 0, maxDragDistance);
        //Vector2 clampedDrag = dragDirection.normalized * dragMagnitude;

        //// Calculate the force direction relative to the AR camera
        //Vector3 forwardDirection = arCameraTransform.forward.normalized;
        //Vector3 rightDirection = arCameraTransform.right.normalized;

        //Vector3 force = forwardDirection * clampedDrag.y + rightDirection * clampedDrag.x;
        //force *= throwForceMultiplier;

        //rb.AddForce(force, ForceMode.Impulse);


        Destroy(ball, 5f);
    }
}

