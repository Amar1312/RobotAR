using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    public SpereAnimation _spereAnima;
    public Button _backBtn;
    public GameObject _cameraSpere;
    private CameraSphere _camSpere;

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(BackBtnClick);
        _camSpere = _cameraSpere.GetComponent<CameraSphere>();
    }

    void BackBtnClick()
    {
        _spereAnima.DownAnimation();
        Invoke(nameof(OnCameraSp), 1f);
    }

    void OnCameraSp()
    {
        _camSpere.UpAnimation();
        //_cameraSpere.SetActive(true);
    }
}
