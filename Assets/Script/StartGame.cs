using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject _startGame;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _startGame.transform.position;
        transform.forward = _startGame.transform.forward;
    }

    
}
