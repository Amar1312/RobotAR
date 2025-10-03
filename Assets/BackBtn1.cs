using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackBtn1 : MonoBehaviour
{
    public Button _backBtn;
    public Button _imgBtn;
    //public TrackingManager _tracking;

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(BackBtnClick);
        _imgBtn.onClick.AddListener(ImgeBtnClick);
        //ImageBtn();
    }

    void BackBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ImageBtn()
    {
        //_tracking.enabled = true;

    }
    void ImgeBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
