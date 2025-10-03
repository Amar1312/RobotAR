using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketBallPanel : MonoBehaviour
{
    public Button _playBtn;
    public Button _exitBtn;
    public GameObject _BasketBallCanvas;
    public GameObject _music;
    public GameObject _exitPlayerPanel;
    private Basketball_game_manager _basketBallManager;

    public List<Button> _otherPlayBtn;
    public GameObject _HeandCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _basketBallManager = Camera.main.gameObject.GetComponent<Basketball_game_manager>();
        _playBtn.onClick.AddListener(PlayBtnClick);
        _exitBtn.onClick.AddListener(ExitBtnClick);

        if (PlayerPrefs.HasKey("CouponCount"))
        {
            _basketBallManager._couponCount = PlayerPrefs.GetInt("CouponCount");
        }
    }

    public void PlayBtnClick()
    {
        _BasketBallCanvas.SetActive(true);
        _exitBtn.gameObject.SetActive(true);
        _playBtn.gameObject.SetActive(false);
        _music.SetActive(true);
        _basketBallManager.enabled = true;
        _basketBallManager.RestartGame();

        for (int i = 0; i < _otherPlayBtn.Count; i++)
        {
            _otherPlayBtn[i].interactable = false;
        }
        _exitPlayerPanel.SetActive(false);
        _HeandCanvas.SetActive(true);
        Invoke(nameof(OffCanvas), 2f);
    }

    public void ExitBtnClick()
    {
        _BasketBallCanvas.SetActive(false);
        _exitBtn.gameObject.SetActive(false);
        _playBtn.gameObject.SetActive(true);
        _music.SetActive(false);
        _basketBallManager.enabled = false;
        for (int i = 0; i < _otherPlayBtn.Count; i++)
        {
            _otherPlayBtn[i].interactable = true;
        }
    }

    void OffCanvas()
    {
        _HeandCanvas.SetActive(false);
    }
}
