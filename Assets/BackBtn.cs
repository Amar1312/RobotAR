using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackBtn : MonoBehaviour
{
    public Button _backBtn;
    public Button _imageBtn;
    public TrackingManager _tracking;

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(BackBtnClick);
        _imageBtn.onClick.AddListener(ImageBtnClick);
        ImageBtn();
    }

    void BackBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ImageBtn()
    {
        _tracking.enabled = true;
    }

    public void ImageBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
