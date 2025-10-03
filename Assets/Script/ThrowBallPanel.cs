using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowBallPanel : MonoBehaviour
{
    public Button _playBtn;
    public Button _exitBtn;
    public GameObject _ThrowBallCanvas;
    public GameObject _exitPlayerPanel;
    private ThrowGameManager _ThrowBallManager;

    public List<Button> _otherPlayBtn;
    public GameObject _HeandCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _ThrowBallManager = Camera.main.gameObject.GetComponent<ThrowGameManager>();
        _playBtn.onClick.AddListener(PlayBtnClick);
        _exitBtn.onClick.AddListener(ExitBtnClick);
    }

    public void PlayBtnClick()
    {
        _ThrowBallCanvas.SetActive(true);
        _ThrowBallManager.enabled = true;
        //_exitBtn.gameObject.SetActive(true);
        _playBtn.gameObject.SetActive(false);
        for(int i = 0; i < _otherPlayBtn.Count; i++)
        {
            _otherPlayBtn[i].interactable = false;
        }
        _exitPlayerPanel.SetActive(false);
        _HeandCanvas.SetActive(true);
        Invoke(nameof(OffCanvas), 2f);
    }

    public void ExitBtnClick()
    {
        _ThrowBallCanvas.SetActive(false);
        _ThrowBallManager.enabled = false;
        //_StrtthrowCanvas.SetActive(false);
        //_exitBtn.gameObject.SetActive(false);
        _playBtn.gameObject.SetActive(true);
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
