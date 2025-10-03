using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggsPanel : MonoBehaviour
{
    public Button _playBtn;
    public Button _exitBtn;
    public GameObject _EggsCanvas;
    public GameObject _music;
    public GameObject _exitPlayerPanel;
    //private  GameObject _trajetoryEgg;
    public EggsGameManager _eggsManager;
    public GameObject _StartPanel;

    //private  GameObject _HeandCanvas;
    // Start is called before the first frame update
    void Start()
    {
        _eggsManager = Camera.main.gameObject.GetComponent<EggsGameManager>();
        _playBtn.onClick.AddListener(PlayBtnClick);
        _exitBtn.onClick.AddListener(ExitBtnClick);
        //_HeandCanvas = EggsGameManager.Instance._heandCanvas;
        //_trajetoryEgg = EggsGameManager.Instance._eggTra;
    }

    public void PlayBtnClick()
    {
        _StartPanel.SetActive(true);
        //_eggsManager.enabled = true;
        //_EggsCanvas.SetActive(true);
        _exitBtn.gameObject.SetActive(true);
        _playBtn.gameObject.SetActive(false);
        //_music.SetActive(true);

        //_exitPlayerPanel.SetActive(false);
        ////_HeandCanvas.SetActive(true);
        //_eggsManager._heandCanvas.SetActive(true);
        ////_trajetoryEgg.SetActive(true);
        //_eggsManager._eggTra.SetActive(true);


        //Invoke(nameof(OffCanvas), 2f);
    }

    public void ExitBtnClick()
    {
        _EggsCanvas.SetActive(false);
        _exitBtn.gameObject.SetActive(false);
        _playBtn.gameObject.SetActive(true);
        _music.SetActive(false);
        _eggsManager._eggTra.SetActive(false);
        
        _eggsManager.enabled = false;
    }
    void OffCanvas()
    {
        _eggsManager._heandCanvas.SetActive(false);
    }



    public void StartGame()
    {
        _eggsManager.enabled = true;
        _EggsCanvas.SetActive(true);
        _exitBtn.gameObject.SetActive(true);
        _playBtn.gameObject.SetActive(false);
        _music.SetActive(true);

        _exitPlayerPanel.SetActive(false);
        //_HeandCanvas.SetActive(true);
        _eggsManager._heandCanvas.SetActive(true);
        //_trajetoryEgg.SetActive(true);
        _eggsManager._eggTra.SetActive(true);


        Invoke(nameof(OffCanvas), 2f);
    }
}
