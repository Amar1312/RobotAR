using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscrit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("test");
            Debug.Log(transform.forward);
            Vector3 vector = new Vector3(2, 2, 2);
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 50, ForceMode.Acceleration);
        }
    }
}
