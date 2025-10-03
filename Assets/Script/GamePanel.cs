using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GamePanel : MonoBehaviour
{

    public GameObject targets_parent;

    [Header("UI")]
    [SerializeField] Text score_text_component = null;      // Link to UI component

    [Header("WIN_LOSE")]
    [SerializeField] GameObject dialog = null;                   // UI game object to show when player completes level

    [Header("Timer")]
    [SerializeField] Text ui_time_counter = null;
    [SerializeField] Text ui_score_remaning = null;

    [Header("BackGround Obj")]
    public GameObject _wellObj;


    //public ProjectileThrow _projeThrow;
    public GameObject _powerPanel;
    public Button _powerBtn;
    public List<TextMeshProUGUI> _message;

    //public GameObject _powerModel;
    //public GameObject _heandCanvas;
    private EggsGameManager _egg;

    //public Button _messBtn;

    // Start is called before the first frame update
    void Start()
    {
        //_messBtn.onClick.
    }

    private void Awake()
    {
        _egg = Camera.main.gameObject.GetComponent<EggsGameManager>();
        _egg.score_text_component = score_text_component;
        _egg.dialog = dialog;
        _egg.ui_time_counter = ui_time_counter;
        _egg.ui_score_remaning = ui_score_remaning;
        _egg._wellObj = _wellObj;
        _egg._powerBtn = _powerBtn;
        _egg._powerPanel = _powerPanel;
        _egg.targets_parent = targets_parent;

        for (int i = 0; i< _message.Count; i++)
        {
            _egg._message.Add(_message[i]);
        }
    }

    bool _onWall;
    public void BackGroundMess()
    {
        
        if (!_onWall)
        {
            _wellObj.SetActive(false);
            _onWall = !_onWall;
        }
        else
        {
            _wellObj.SetActive(true);
            _onWall = !_onWall;
        }
    }
}
