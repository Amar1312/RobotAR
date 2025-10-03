using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddForce(Vector3 force)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(force);
    }
}
