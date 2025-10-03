using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenScene(int indexNo)
    {
        SceneManager.LoadScene(indexNo);
    }
}
