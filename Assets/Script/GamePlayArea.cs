using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayArea : MonoBehaviour
{
    public GameObject _exitPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            _exitPanel.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "MainCamera")
        {
            _exitPanel.SetActive(true);
        }
    }
}
