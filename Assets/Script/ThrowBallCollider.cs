using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallCollider : MonoBehaviour
{
    public GameObject _throwBallCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "MainCamera")
        {
            Debug.Log(collision.gameObject.tag);
            _throwBallCanvas.SetActive(true);
        }
        
    }
}
