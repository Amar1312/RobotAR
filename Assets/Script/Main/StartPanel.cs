using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public Button _startBtn;
    public Button _couponBtn;
    public Button _urlBtn;

    // Start is called before the first frame update
    void Start()
    {
        _startBtn.onClick.AddListener(StartBtnClick);
        _couponBtn.onClick.AddListener(CouponBtnClick);
        _urlBtn.onClick.AddListener(UrlBtnClick);
    }

    void StartBtnClick()
    {
        UIManager.Instance.LoadNextScene();
    }

    void CouponBtnClick()
    {
        UIManager.Instance.ToggleCouponPanel(true);
        UIManager.Instance.ToggleStarePanel(false);
    }

    void UrlBtnClick()
    {
        Application.OpenURL("https://www.mixed.place/");
    }
}
