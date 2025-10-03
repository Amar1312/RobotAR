using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CouponPanel : MonoBehaviour
{
    public Button _backBtn;
    public int _couponCount1;
    public int _couponCount2;
    private int _perchCount;
    public GameObject _firstCoupon;
    public GameObject _SecondCoupon;


    private void OnEnable()
    {

        if (PlayerPrefs.HasKey("CouponCount"))
        {
            _perchCount = PlayerPrefs.GetInt("CouponCount");
        }

        if (_couponCount1 <= _perchCount)
        {
            _firstCoupon.SetActive(true);
        }

        if (_couponCount2 <= _perchCount)
        {
            _SecondCoupon.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _backBtn.onClick.AddListener(BackBtnClick);
    }

    void BackBtnClick()
    {
        UIManager.Instance.ToggleCouponPanel(false);
        UIManager.Instance.ToggleStarePanel(true);
    }

}
