using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int _maxCup;
    public int _count = 0;
    public ResetThrow _reset;
    [SerializeField] GameObject add_score_text_prefab = null; // Add score text effect prefab
    [SerializeField] Transform add_score_text_transform = null; // Position where to appear add score text effect

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            _count = _count + 1;
        }
        if(_count == _maxCup)
        {
            _count = 0;
            Invoke(nameof(ResetBall), 2f);
        }
        
    }
    void ResetBall()
    {
        ThrowGameManager.Instance.AddScore(1);
        _reset.ResetBtnClick();
        ScoreAnimation();
    }

    public void ScoreAnimation()
    {
        if (add_score_text_prefab != null)
        {
            GameObject txt = Instantiate(add_score_text_prefab, transform.position, add_score_text_transform.rotation); // Creates add score text effect
            Destroy(txt, txt.GetComponentInChildren<Text>().GetComponent<Animation>().clip.length); // Destroy add score effect GO after animation done playing
            txt.transform.position = add_score_text_transform.position; // Assign position of effect
            txt.GetComponentInChildren<Text>().text = "+" + 1.ToString(); // Set current hoop score to effect text
            txt.GetComponentInChildren<Text>().enabled = true; // Enable this ad score effect
            txt.GetComponentInChildren<Text>().GetComponent<Animation>().Play(); // Play animation of effect
        }
    }
}
