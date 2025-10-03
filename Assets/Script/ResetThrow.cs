using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetThrow : MonoBehaviour
{
    public Button _resetBtn;
    public List<GameObject> _transformPosition;
    public List<Vector3> _position;
    public List<Quaternion> _rotetion;
    //public ThrowBallController _throw;
    public Counter _counter;
    //public TextMeshProUGUI _Scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _transformPosition.Count; i++)
        {
            _position.Add(_transformPosition[i].transform.position);
            _rotetion.Add(_transformPosition[i].transform.rotation);
        }

        _resetBtn.onClick.AddListener(ResetBtnClick);
    }

    public void ResetBtnClick()
    {
        for (int i = 0; i < _transformPosition.Count; i++)
        {
            _transformPosition[i].transform.position = _position[i];
            _transformPosition[i].transform.rotation = _rotetion[i];

            //_throw._scoreCount = 0;
            //_Scoretxt.text = 0.ToString();
            
        }
        _counter._count = 0;
    }
}
