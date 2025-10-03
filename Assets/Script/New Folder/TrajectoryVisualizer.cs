using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryVisualizer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float timeStep = 0.1f;
    public float totalTime = 2f;  // Total time for the parabola
    public Vector3 initialVelocity;
    public Vector3 startPosition;
    public float gravity = 9.81f;

    void Start()
    {
        lineRenderer.positionCount = Mathf.CeilToInt(totalTime / timeStep);
        DrawTrajectory();
    }

    void DrawTrajectory()
    {
        for (float t = 0; t < totalTime; t += timeStep)
        {
            float x = startPosition.x + initialVelocity.x * t;
            float y = startPosition.y + initialVelocity.y * t - 0.5f * gravity *t  *t;
            float z = startPosition.z + initialVelocity.z * t;

            lineRenderer.SetPosition(Mathf.FloorToInt(t / timeStep), new Vector3(x, y, z));
        }
    }
}
