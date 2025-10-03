using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
// ------------------
// Author:  RASKALOF (https://connect.unity.com/u/dmitry-raskalov)
// Version: 1.0
// Date:    12.09.2019

public class EggsGameManager : MonoBehaviour
{
    // Global vars (can be changed from inspector)
    [Header("COMMON")]
    [SerializeField] GameObject ball = null;                // Ball prefab
    public Transform spawn_transform = null;      // Transform where ball will be instantiated
    public GameObject targets_parent = null;      // Empty GO which handles all targets GOs
    [Header("RULES")]
    [SerializeField] byte balls_amount = 10;         // Maximum amount of balls to throw
    [SerializeField] byte percent_to_win = 80;       // This value and more means player won, less - means player lose
    [SerializeField] byte next_level = 1;            // (If needed) next level's id if player won
    [SerializeField] float spawn_delay = 0.1f;       // How long to wait between new ball spawns
    [Header("UI")]
    [SerializeField] string level_text = "LEVEL : ";  // Text to display with level counter
    [SerializeField] string level_numba = "X";       // Level number cant be grabbed from build settings, cos you can have any kind of sorting, better to controll this value for UI
    [SerializeField] Text level_text_component = null;      // Link to UI component
    [SerializeField] string balls_text = "THROWS: "; // Text to display with throws counter
    [SerializeField] Text balls_text_component = null;      // Link to UI component
    [SerializeField] string score_text = "SCORE: ";  // Just text to display with score points
    public Text score_text_component = null;      // Link to UI component
    [Header("WIN_LOSE")]
    public GameObject dialog = null;                   // UI game object to show when player completes level
    [SerializeField] string win_title = "COMPLETED";      // Header to display in win dialog
    [SerializeField] string lose_title = "FAILED";        // Header to display in lose dialog
    [SerializeField] string score_label = "YOUR SCORE: "; // Header to display in win dialog
    [SerializeField] Button restart_button = null;        // Restart button link to disable at gameover
    [Header("MISC")]
    [SerializeField] AudioClip win_sound = null;          // Sound to play when player won 
    [SerializeField] AudioClip lose_sound = null;         // Sound to play when player lose 
    [SerializeField] AudioClip power_sound = null;         // Sound to play when player lose 

    [Header("Wall")]
    //[SerializeField] Transform Wall;

    [Header("Timer")]
    public double game_time;
    public int game_WinScore;
    private double game_time_seconds = 20;
    [SerializeField] string ui_time_text = "TIME LEFT: ";
    public Text ui_time_counter = null;
    public Text ui_score_remaning = null;

    [Header("BackGround Obj")]
    public GameObject _wellObj;

    public int _winone;
    public GameObject _eggTra;
    public int _firstThrow;
    public int _power;
    public int _throwCount;
    public bool _throwTrajectile;
    public ProjectileThrow _projeThrow;
    public Button _powerBtn;
    public GameObject _dummy;
    public bool _powerClickBtn;
    public GameObject _powerModel;
    public GameObject _heandCanvas;
    public GameObject _powerPanel;

    public List<TextMeshProUGUI> _message;

    // Private (system purposes)
    byte current_score = 0; // Current player score
    byte powerCurrent_score = 0;
    byte balls_left = 0; // How much throws left
    int score_to_win = 0; // Score to win level
    byte fail_count = 0; // Fail count
    int random_number = -1; // Used for unique target random
    GameObject current_spawned_ball; // Link to current spawned ball to be abble destroy it if needed or manipulate
    public static EggsGameManager Instance; // Singleton pattern
    bool gameover;


    private void OnEnable()
    {
        _powerClickBtn = false;
        _throwTrajectile = false;

        //UpdateLevelTextUI(level_numba);
        //UpdateBallsUI((byte)balls_left);
        OnGame();
        current_score = 0;
        powerCurrent_score = 0;
        _powerModel.SetActive(false);
        Throw();
        num = 0;
    }

    void OnGame()
    {
        _throwCount = 0;
        
        //_powerBtn.gameObject.SetActive(false);
        _dummy.SetActive(false);
        _projeThrow._powerThrowCount = 0;
        gameover = false;
        score_to_win = 0;
        fail_count = 0;
        balls_left = balls_amount;
        
        ShowWinMenu(false);
        ShowLoseMenu(false);
        
        SpawnTarget();
        UpdateUI(0);
        game_time_seconds = game_time;
        StartCoroutine(nameof(TimeCalc));
    }
    private void Start()
    { // Used for initialization purposes
        //gameover = false;
        if (Instance == null) Instance = this;
        if (PlayerPrefs.HasKey("EggsWin"))
        {
            _winone = PlayerPrefs.GetInt("EggsWin");
        }
        //_powerBtn.onClick.AddListener(PowerClick);
        //score_to_win = 0;
        //fail_count = 0;
        //balls_left = balls_amount;
        //current_score = 0;
        //UpdateLevelTextUI(level_numba);
        //UpdateBallsUI((byte)balls_left);
        //ShowWinMenu(false);
        //ShowLoseMenu(false);
        //Throw();
        //SpawnTarget();
        //UpdateUI(0);
        _powerBtn.onClick.AddListener(PowerClick);
    }

    public void AddScore(byte amount)
    { // Add score when target hitted
        

        if (_powerClickBtn)
        {
            powerCurrent_score += amount;
            UpdateUI(powerCurrent_score);
        }
        else
        {
            current_score += amount; // Increase score
            UpdateUI(current_score); // Update UI
        }
        //if (current_score == game_WinScore)
        //{
        //    ShowWinMenu(true);
        //}
        //else
        //{
        //    ui_score_remaning.text = (game_WinScore - current_score).ToString() + " Remaning";
        //    ui_score_remaning.gameObject.SetActive(true);
        //    Invoke(nameof(OffRemaning), 1f);
        //}
        
    }
    public void OffRemaning()
    {
        ui_score_remaning.gameObject.SetActive(false);
    }

    public void AddFail()
    { // Add fail count to counter
        //fail_count++;
        //SpawnTarget(); // Spawn new target
    }

    public byte GetBallsLeft()
    {
        return balls_left;
    }

    public void Throw()
    { 
       
        _throwCount++;

        if (_powerClickBtn)
        {
            if (current_spawned_ball != null) Destroy(current_spawned_ball); // Destroy current ball if exists
            //StopCoroutine(nameof(SpawnAuto));
            _throwTrajectile = true;
            _projeThrow.ThrowBall();
           // StartCoroutine(nameof(SpawnTra));
            _dummy.SetActive(true);
        }
        else
        {
            SpawnBall();
            //StopCoroutine(nameof(SpawnTra));
            //StartCoroutine(nameof(SpawnAuto)); // Spawn new ball
        }
        

    }

    

    public IEnumerator SpawnTra()
    {
        if (IsButton())
        {
            yield break;
        }
        yield return new WaitForSeconds(spawn_delay);
        _projeThrow.ThrowBall();
    }
    


    public IEnumerator GameEnd(float delay = 0.5f)
    {
        if (!gameover)
        {
            gameover = true;
            yield return new WaitForSeconds(delay);
            DisableUI(false);
            if (current_spawned_ball != null) Destroy(current_spawned_ball); // Destroy current ball if exists
            DisableAllTargets();

            if (Mathf.RoundToInt(((float)current_score / (float)score_to_win) * 100f) >= percent_to_win) ShowWinMenu(true); // Calculate win conditions
            else ShowLoseMenu(true);
        }
    }

    public void RestartLevel()
    {
        _throwCount = 0;
        num = 0;
        _eggTra.SetActive(true);
        //_powerBtn.gameObject.SetActive(false);
        
        _powerClickBtn = false;
        _throwTrajectile = false;
        _dummy.SetActive(false);
        _projeThrow._powerThrowCount = 0;
        
        gameover = false;
        score_to_win = 0;
        fail_count = 0;
        balls_left = balls_amount;
        current_score = 0;
        powerCurrent_score = 0;

        ShowWinMenu(false);
        ShowLoseMenu(false);
        if (current_spawned_ball == null) Throw();
        SpawnTarget();
        UpdateUI(0);
        DisableUI(true);

        game_time_seconds = game_time;
        StartCoroutine(nameof(TimeCalc));

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(next_level);
    }

    public void LaunchLevel(int level_number)
    {
        SceneManager.LoadScene(level_number);
    }

    public void LaunchLevel(string level_name)
    {
        SceneManager.LoadScene(level_name);
    }

    public IEnumerator SpawnAuto()
    {
        _dummy.SetActive(false);
        yield return new WaitForSeconds(spawn_delay);
        SpawnBall(); // Spawn ball after delay
    }

    public void SpawnBall()
    {
        if (this.enabled && !gameover)
        {
            current_spawned_ball = Instantiate(ball, spawn_transform.position, Quaternion.identity, spawn_transform); // Get link to current active ball to manipulate
            current_spawned_ball.transform.rotation = new Quaternion(0f, 0f, 0f,0f);
        }
    }

    public void SpawnTarget()
    { // Used for enabling one target from array and disable others
        DisableAllTargets();
        SetText();
        if (GetBallsLeft() > 0)
        { // If we can play
            int child = GetUniqueRandom(0, targets_parent.transform.childCount, ref random_number); // Generate random target id
            targets_parent.transform.GetChild(child).gameObject.SetActive(true); // Enable choosen target
            score_to_win += targets_parent.transform.GetChild(child).gameObject.GetComponent<EggsTarget>().GetTargetScore(); // Increase total awailable score counter
        }
    }

    public void DisableAllTargets()
    {
        foreach (Transform t in targets_parent.transform)
        {
            t.gameObject.SetActive(false);
        }
    }

    int GetUniqueRandom(int min, int max, ref int exclude)
    { // This method should always return unique number
        int tmp = UnityEngine.Random.Range(min, max);
        if (tmp == exclude)
        {
            return GetUniqueRandom(min, max, ref exclude);
        }
        exclude = tmp;
        return exclude;
    }

    public void UpdateUI(byte score)
    {
        if (score_text_component != null) score_text_component.text = score_text + score /*+ "/" + game_WinScore.ToString()*/;
        else
        {
            Debug.LogWarning("UpdateUI: score_text_component is not attached! Is it OK?");
        }
    }

    public void UpdateBallsUI(byte score)
    {
        if (balls_text_component != null) balls_text_component.text = balls_text + score;
        else
        {
            Debug.LogWarning("UpdateBallsUI: balls_text_component is not attached! Is it OK?");
        }
    }

    public void UpdateLevelTextUI(string value)
    {
        if (level_text_component != null) level_text_component.text = level_text + value;
        else
        {
            Debug.LogWarning("UpdateLevelTextUI: level_text_component is not attached! Is it OK?");
        }
    }

    public void DisableUI(bool Status)
    {
        score_text_component?.gameObject.SetActive(Status);
    }

    public void ShowWinMenu(bool status)
    {
        //_powerBtn.gameObject.SetActive(false);
        dialog?.SetActive(status);
        if (status)
        {
            GetComponent<AudioSource>()?.PlayOneShot(win_sound);
            //dialog.GetComponent<DialogEggHandler>().ShowDialog(win_title, score_label, true, current_score, game_WinScore);
        }
        Destroy(current_spawned_ball);
        StopCoroutine(nameof(TimeCalc));
    }

    public void ShowLoseMenu(bool status)
    {
        //_powerBtn.gameObject.SetActive(false);
       
        dialog?.SetActive(status);
        if (status)
        {
            _powerModel.SetActive(false);
            GetComponent<AudioSource>()?.PlayOneShot(lose_sound);
            dialog.GetComponent<DialogEggHandler>().ShowDialog(lose_title, score_label, false, current_score, game_WinScore, powerCurrent_score);
        }
        Destroy(current_spawned_ball);
    }

    private void OnDisable()
    {
        foreach (Transform child in spawn_transform)
        {
            Destroy(child.gameObject);
        }
        //foreach (Transform child in Wall)
        //{
        //    Destroy(child.gameObject);
        //}
        StopAllCoroutines();
    }

    IEnumerator TimeCalc()
    { // Time calculations
        yield return new WaitForSeconds(1f); // Delay to load stuff from level start
        DateTime end_time = DateTime.Now.AddSeconds(game_time_seconds);

        if (!gameover)
        {
            while (DateTime.Now < end_time)
            {
                game_time_seconds = (end_time - DateTime.Now).TotalSeconds;
                UpdateUITime();
                yield return null;
            }
        }
        EndGame(); // If time is ended call game end
    }

    void EndGame()
    {
        StopAllCoroutines(); // Stop time calcs
        game_time_seconds = 0; // Game time zero
        gameover = true; // Game end flag = true
        
        if (_powerClickBtn)
        {
            
            ShowLoseMenu(true);
        }
        else
        {
            //_powerBtn.gameObject.SetActive(true);
            if (current_spawned_ball != null) Destroy(current_spawned_ball);
            _powerModel.SetActive(true);
            //Invoke(nameof(PowerClick), 5f);
            _powerPanel.SetActive(true);
        }
    }

    void PowerClick()
    {
        UpdateUI(0);
        _powerClickBtn = true;
        _throwTrajectile = true;
        GetComponent<AudioSource>()?.PlayOneShot(power_sound);
        OnGame();
        _dummy.SetActive(true);
        _powerModel.SetActive(false);
        _powerPanel.SetActive(false);
    }
    void UpdateUITime()
    {
        ui_time_counter.text = ui_time_text + ((int)(game_time_seconds)).ToString("00");
    }

    public void BackGroundMess()
    {
        //MeshRenderer _wellMess = _wellObj.GetComponent<MeshRenderer>();
        if (_wellObj.activeInHierarchy)
        {
            _wellObj.SetActive(false);
            //_wellMess.enabled = false;
        }
        else
        {
            _wellObj.SetActive(true);
            //_wellMess.enabled = true;
        }
    }


    int num = 0;
    void SetText()
    {
        num++;

        if (num == 1)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Reduce AHT";
            }
            
        }
        else if (num == 2)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Increase upsell";
            }
        }
        else if (num == 3)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Increase FCR";
            }
        }
        else if (num == 4)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Increase CSAT";
            }
        }
        else if (num == 5)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Personalize training";
            }
        }
        else if (num == 6)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Reduce attrition";
            }
        }
        else if (num == 7)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Increase revenue";
            }
        }
        else if (num == 8)
        {
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Increase ESAT";
            }
        }
        else
        {
            num = 0;
            for (int i = 0; i < _message.Count; i++)
            {
                _message[i].text = "Improve SLAs";
            }
        }

        
    }

    public bool IsButton()
    {
        
        // Check if there's a touch point
        if (Touchscreen.current == null) return false;

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        // Raycast against UI
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = touchPosition
        };
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }
}
