using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// RASKALOF, v1.0, Script used for displaying end game menu
public class DialogHandler : MonoBehaviour 
{
    [SerializeField] Text title = null;
    [SerializeField] Text description = null;
    [SerializeField] Button next_button = null;
    [SerializeField] Text coupon_text;
    

    public void ShowDialog(string title, string description, bool enable_next, byte value1, int value2) {
        this.title.text = title;
        this.description.text = description;
        //next_button.interactable = enable_next;
        this.description.text += value1 + "/" + value2;

        if (enable_next && ThrowGameManager.Instance._winone == 0)
        {
            Basketball_game_manager.Instance._couponCount += 1;
            if(Basketball_game_manager.Instance._couponCount == 3)
            {
                coupon_text.text = " You Get Two Coupon Allready";
                coupon_text.gameObject.SetActive(true);
                Basketball_game_manager.Instance._couponCount -= 1;
            }
            else
            {
                coupon_text.text = " You Get Coupon";
                coupon_text.gameObject.SetActive(true);
                ThrowGameManager.Instance._winone = 1;
                PlayerPrefs.SetInt("ThrowBallWin", 1);
            }

            PlayerPrefs.SetInt("CouponCount", Basketball_game_manager.Instance._couponCount);

        }
        else
        {
            coupon_text.gameObject.SetActive(false);
        }
        
    }
}
