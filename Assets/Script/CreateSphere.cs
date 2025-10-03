using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSphere : MonoBehaviour
{
    public GameObject sphere;
    float startposx,endpos,startposy, endposy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(transform.forward);
        }

        if (Input.GetMouseButtonDown(0))
        {            
            startposx = Input.mousePosition.x;
            startposy = Input.mousePosition.y;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endposy = Input.mousePosition.y;
            endpos = Input.mousePosition.x;
            GameObject obj = Instantiate(sphere, this.transform.position, this.transform.rotation);
            float deltaposx = endpos - startposx;
            float deltaposy = endposy - startposy;

            Vector3 test = (this.transform.forward * 1000) + new Vector3(0, deltaposy, 0) + new Vector3(deltaposx,0,0);
            obj.GetComponent<TestForce>().AddForce(test);
        }
    }
}
