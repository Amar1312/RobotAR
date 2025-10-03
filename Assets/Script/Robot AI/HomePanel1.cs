using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePanel1 : MonoBehaviour
{
    
    public Button _gameBtn;
    public Button _aiBtn;

    // Start is called before the first frame update
    void Start()
    {
        _aiBtn.onClick.AddListener(AiBtnClick);
    }

    void AiBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
