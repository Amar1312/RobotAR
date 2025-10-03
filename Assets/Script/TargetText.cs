using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetText : MonoBehaviour
{
    public TextMeshProUGUI _message;

    private void OnEnable()
    {
        SetText();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SetText()
    {
        int num = Random.Range(0, 9);
        if (num == 0)
        {
            _message.text = "Reduce AHT";
        }
        else if (num == 1)
        {
            _message.text = "Increase upsell";
        }
        else if (num == 2)
        {
            _message.text = "Increase FCR";
        }
        else if (num == 3)
        {
            _message.text = "Increase CSAT";
        }
        else if (num == 4)
        {
            _message.text = "Personalize training";
        }
        else if (num == 5)
        {
            _message.text = "Reduce attrition";
        }
        else if (num == 6)
        {
            _message.text = "Increase revenue";
        }
        else if (num == 7)
        {
            _message.text = "Increase ESAT";
        }
        else
        {
            _message.text = "Improve SLAs";
        }
    }
}
