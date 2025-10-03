using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    public GameObject _loadingPanel;
    public GameObject _homePanel;

    private void OnEnable()
    {
        //Invoke(nameof(StartGame), 2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(StartGame), 2f);
    }

    public void StartGame()
    {
        _homePanel.SetActive(true);
        _loadingPanel.SetActive(false);
    }
}
