using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModel : MonoBehaviour
{
    public float _xRotetion;
    public float _yRotetion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(_xRotetion,_yRotetion, 0);
    }
}
