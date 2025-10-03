using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign your ball prefab here
    public Transform arCameraTransform;  // The point where the ball spawns
    public LineRenderer trajectoryRenderer;  // Assign a LineRenderer for trajectory visualization
    public float throwForceMultiplier = 10f;
    public float forwardForceMultiplier = 10f;
    public float verticalForceMultiplier = 5f;

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
        //Vector2 dragDirection = dragStart - dragEnd;
        Vector2 dragDirection = dragEnd - dragStart;
        Vector3 force = new Vector3(dragDirection.x, dragDirection.y, 0) * throwForceMultiplier;
        trajectoryRenderer.positionCount = 30;

        Vector3 startPoint = arCameraTransform.position;
        Vector3 velocity = force / ballPrefab.GetComponent<Rigidbody>().mass;

        for (int i = 0; i < 30; i++)
        {
            float time = i * 0.1f;
            Vector3 point = startPoint + velocity * time + 0.5f * Physics.gravity * time * time;
            trajectoryRenderer.SetPosition(i, point);
        }



        //Vector2 dragDirection = dragEnd - dragStart;
        ////Vector2 dragDirection = dragStart - dragEnd;
        //Vector3 force = arCameraTransform.forward * dragDirection.magnitude * throwForceMultiplier;

        //trajectoryRenderer.positionCount = 30;

        //Vector3 startPoint = arCameraTransform.position;
        //Vector3 velocity = force / ballPrefab.GetComponent<Rigidbody>().mass;

        //for (int i = 0; i < 30; i++)
        //{
        //    float time = i * 0.1f;
        //    Vector3 point = startPoint + velocity * time + 0.5f * Physics.gravity * time * time;
        //    trajectoryRenderer.SetPosition(i, point);
        //}


        //Vector2 dragDirection = dragStart - dragEnd;

        //// Calculate forces
        //float forwardForce = dragDirection.magnitude * forwardForceMultiplier;
        //float verticalForce = dragDirection.y * verticalForceMultiplier;

        //Vector3 initialVelocity = arCameraTransform.forward * forwardForce;
        //initialVelocity.y = verticalForce;

        //trajectoryRenderer.positionCount = 30;

        //Vector3 startPoint = arCameraTransform.position;
        //Vector3 velocity = initialVelocity;

        //for (int i = 0; i < 30; i++)
        //{
        //    float time = i * 0.1f;
        //    Vector3 point = startPoint + velocity * time + 0.5f * Physics.gravity * time * time;
        //    trajectoryRenderer.SetPosition(i, point);
        //}
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, arCameraTransform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        //Vector2 dragDirection = dragStart - dragEnd;
        Vector2 dragDirection = dragEnd - dragStart;
        Vector3 force = new Vector3(dragDirection.x, dragDirection.y, 0) * throwForceMultiplier;

        rb.AddForce(force, ForceMode.Impulse);



        //GameObject ball = Instantiate(ballPrefab, arCameraTransform.position, Quaternion.identity);
        //Rigidbody rb = ball.GetComponent<Rigidbody>();

        ////Vector2 dragDirection = dragStart - dragEnd;
        //Vector2 dragDirection = dragEnd - dragStart;
        //Vector3 force = arCameraTransform.forward * dragDirection.magnitude * throwForceMultiplier;

        //rb.AddForce(force, ForceMode.Impulse);


        //GameObject ball = Instantiate(ballPrefab, arCameraTransform.position, Quaternion.identity);
        //Rigidbody rb = ball.GetComponent<Rigidbody>();

        //// Calculate forces
        //Vector2 dragDirection = dragStart - dragEnd;
        //float forwardForce = dragDirection.magnitude * forwardForceMultiplier;
        //float verticalForce = dragDirection.y * verticalForceMultiplier;

        //Vector3 initialVelocity = arCameraTransform.forward * forwardForce;
        //initialVelocity.y = verticalForce;

        //rb.AddForce(initialVelocity, ForceMode.Impulse);
        Destroy(ball, 5f);
    }
}