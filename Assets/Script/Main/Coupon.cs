using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coupon : MonoBehaviour
{
    public TextMeshProUGUI _couponText;

    public int _couponCount;
    private int _perchCount;


    private void OnEnable()
    {
        //if (PlayerPrefs.HasKey("CouponCount"))
        //{
        //    _perchCount = PlayerPrefs.GetInt("CouponCount");
        //}

        //if(_couponCount1 <= _perchCount)
        //{
        //    _couponText.text = "Coupon ";
        //}
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
