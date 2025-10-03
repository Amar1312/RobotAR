using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallNear : MonoBehaviour
{
    public GameObject _nearPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            _nearPanel.SetActive(true);
            Debug.Log("Player Near");
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            _nearPanel.SetActive(false);
            Debug.Log("Player Near");
        }
    }
}
