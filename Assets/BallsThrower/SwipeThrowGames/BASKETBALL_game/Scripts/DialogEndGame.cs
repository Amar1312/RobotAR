using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// RASKALOF, v1.0, Script handle end game dialog

public class DialogEndGame : MonoBehaviour 
{ 
    [SerializeField] Text title = null; // Link to title
    [SerializeField] Text description = null; // Link to description
    [SerializeField] Text coupon_text;
    

    public void ShowDialog(string title, string description, int value,int WinValue, bool enable_next) {
        this.title.text = title;
        this.description.text = description;
        this.description.text += value +"/"+ WinValue.ToString();

        if (enable_next && Basketball_game_manager.Instance._winone == 0 )
        {
            Basketball_game_manager.Instance._couponCount += 1;
            if (Basketball_game_manager.Instance._couponCount == 3)
            {
                coupon_text.text = " You Get Two Coupon Allready";
                coupon_text.gameObject.SetActive(true);
                Basketball_game_manager.Instance._couponCount -= 1;
            }
            else
            {
                coupon_text.text = " You Get Coupon";
                coupon_text.gameObject.SetActive(true);
                Basketball_game_manager.Instance._winone = 1;
                PlayerPrefs.SetInt("BasketBallWin", 1);
            }

            PlayerPrefs.SetInt("CouponCount", Basketball_game_manager.Instance._couponCount);
        }
        else
        {
            coupon_text.gameObject.SetActive(false);
        }
    }
}
