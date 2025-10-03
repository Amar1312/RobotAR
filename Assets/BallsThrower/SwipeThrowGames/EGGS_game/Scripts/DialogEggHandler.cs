using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogEggHandler : MonoBehaviour
{
    [SerializeField] Text title = null;
    [SerializeField] Text description = null;
    [SerializeField] Button next_button = null;
    [SerializeField] Text coupon_text;
    [SerializeField] Text HightScore_text;

    public int HighScore;

    public void ShowDialog(string title, string description, bool enable_next, byte value1, int value2, byte power_score)
    {
        this.title.text = title;
        this.description.text = description;
        //next_button.interactable = enable_next;
        this.description.text += value1 /*+ "/" + value2*/;
        EggsGameManager.Instance._eggTra.SetActive(false);

        //if (PlayerPrefs.HasKey("EggsHighScore"))
        //{
        //    HighScore = PlayerPrefs.GetInt("EggsHighScore");
        //}
        //if(value1 >= HighScore)
        //{
        //    PlayerPrefs.SetInt("EggsHighScore", value1);
        //    HighScore = value1;
        //}

        HightScore_text.text = power_score.ToString();


        if (enable_next && EggsGameManager.Instance._winone == 0)
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
                EggsGameManager.Instance._winone = 1;
                PlayerPrefs.SetInt("EggsWin", 1);
            }

            PlayerPrefs.SetInt("CouponCount", Basketball_game_manager.Instance._couponCount);
        }
        else
        {
            coupon_text.gameObject.SetActive(false);
        }
    }

    public void HomeScene()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartLevel()
    {
        EggsGameManager.Instance.RestartLevel();
    }

    public void WallMesh()
    {
        //EggsGameManager.Instance.BackGroundMess();
    }
}
