using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRay : MonoBehaviour
{
    public GameObject _cameraSpere;
    public GameObject _Spere;
    public SpereAnimation _spereAnim;

    public LayerMask _layer;
    private Vector3 Point;
    private CameraSphere _camSpere;

    // Start is called before the first frame update
    void Start()
    {
        _camSpere = _cameraSpere.GetComponent<CameraSphere>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layer))
            {
                //_Spere.SetActive(true);
                if (_cameraSpere.activeInHierarchy)
                {
                    _camSpere.DownAnimation();
                }
                else
                {
                    //_Spere.SetActive(true);
                    _spereAnim.DownAnimation();
                }

                //_Spere.transform.position = hitInfo.point;
                //_spereAnim.UpAnimation();
                
                Point = hitInfo.point;
                Invoke(nameof(SetUpDown), 1f);
            }
        }
    }

    void SetUpDown()
    {
        _Spere.transform.position = Point;

        _spereAnim.UpAnimation();
    }
}
