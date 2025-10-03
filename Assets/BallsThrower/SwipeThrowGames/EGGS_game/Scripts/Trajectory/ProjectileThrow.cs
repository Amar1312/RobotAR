using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TrajectoryPredictor))]
public class ProjectileThrow : MonoBehaviour
{
    TrajectoryPredictor trajectoryPredictor;

    [SerializeField]
    GameObject objectToThrow;

    [SerializeField, Range(0.0f, 50.0f)]
    float force;

    [SerializeField]
    Transform StartPosition;

    public InputAction fire;

    public GameObject _dammy;
    public float _mass;
    public int _powerThrowCount;

    void OnEnable()
    {
        trajectoryPredictor = GetComponent<TrajectoryPredictor>();

        if (StartPosition == null)
            StartPosition = transform;

        fire.Enable();
        fire.performed += ThrowObject;
    }

    void Update()
    {
        Predict();

        //if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame) // Touch input for release
        //{
        //    //ThrowBall();
        //    if(EggsGameManager.Instance._throwTrajectile)
        //    {
        //        ThrowBall();
        //        Debug.Log("Throw Trajectile ");
        //        //EggsGameManager.Instance._throwTrajectile = false;

        //    }

        //}

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Ended) // Touch input for release
        {
            
            if (EggsGameManager.Instance._throwTrajectile)
            {
                _powerThrowCount++;
                EggsGameManager.Instance?.Throw();
                _dammy.SetActive(false);
                Invoke(nameof(OnDammy), 0.2f);
            }
        }
    }

    void Predict()
    {
        trajectoryPredictor.PredictTrajectory(ProjectileData());
    }

    ProjectileProperties ProjectileData()
    {
        ProjectileProperties properties = new ProjectileProperties();
        //Rigidbody r = objectToThrow.GetComponent<Rigidbody>();

        properties.direction = StartPosition.forward;
        properties.initialPosition = StartPosition.position;
        properties.initialSpeed = force;
        properties.mass = _mass;
        properties.drag = 0f;

        return properties;
    }

    void ThrowObject(InputAction.CallbackContext ctx)
    {
        GameObject thrownObject = Instantiate(objectToThrow, StartPosition.position, Quaternion.identity);
        Rigidbody rb = thrownObject.AddComponent<Rigidbody>();
        rb.AddForce(StartPosition.forward * force, ForceMode.Impulse);
        rb.mass = _mass;
        //_dammy.SetActive(false);
        //Invoke(nameof(OnDammy), 0.9f);
        Destroy(thrownObject, 4f);
    }

    public  void ThrowBall()
    {
        GameObject thrownObject = Instantiate(objectToThrow, StartPosition.position, Quaternion.identity);
        Rigidbody rb = thrownObject.AddComponent<Rigidbody>();
        rb.AddForce(StartPosition.forward * force, ForceMode.Impulse);
        rb.mass = _mass;
        //_dammy.SetActive(false);
        //Invoke(nameof(OnDammy), 0.9f);
        Destroy(thrownObject, 4f);

        //EggsGameManager.Instance?.Throw();
        //EggsGameManager.Instance._throwTrajectile = false;
    }

    void OnDammy()
    {
        _dammy.SetActive(true);
    }
}